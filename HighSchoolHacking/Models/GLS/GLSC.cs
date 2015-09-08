using System.Collections.Generic;

namespace HighSchoolHacking.Models.GLS
{
    public class GLSC
    {
        private Dictionary<string, Language> Languages;
        private Dictionary<char, char> SearchEnds;

        public GLSC()
        {
            this.Languages = new Dictionary<string, Language>();
            this.SearchEnds = new Dictionary<char, char> {
                { ' ', ' ' },
                { '{', '}' },
                { '(', ')' }
            };
        }


        /*
        Core parsing
        */

        public string parseCommands(Language language, string[] commandsRaw)
        {
            if (commandsRaw.Length == 0 || (commandsRaw.Length == 1 && commandsRaw[0].Length == 0))
            {
                return "";
            }

            string output = "";
            int numTabs = 0;
            int lastTabRequest = 0;
            bool lastLineSkipped = true;
            object[] command;
            int i;
            int j;

            for (i = 0; i < commandsRaw.Length; i += 1)
            {
                command = this.parseCommand(language, commandsRaw[i], false);

                // Each command is an even-length [string, int, ...]
                for (j = 0; j < command.Length; j += 2)
                {
                    // Special case: a blank line after an inline command is ignored
                    // This is useful for things like lambda types that aren't in every language
                    if (lastTabRequest == Language.INT_MIN && command.Length == 2 && (string)command[0] == "")
                    {
                        lastLineSkipped = true;
                        continue;
                    }

                    if ((int)command[1] == Language.INT_MIN)
                    {
                        if ((string)command[0] != "")
                        {
                            output += " " + command[0];
                        }
                    }
                    else
                    {
                        // Just "\0" changes numTabs without adding a line
                        if ((string)command[j] != "\0" && !lastLineSkipped)
                        {
                            output += "\n";
                        }

                        if ((int)command[j + 1] < 0)
                        {
                            numTabs += (int)command[j + 1];
                            output += this.generateTabs(numTabs);
                            if ((int)command[j] != '\0')
                            {
                                output += command[j];
                            }
                        }
                        else
                        {
                            output += this.generateTabs(numTabs);
                            if ((string)command[j] != "\0")
                            {
                                output += command[j];
                            }
                            numTabs += (int)command[j + 1];
                        }
                    }

                    lastTabRequest = (int)command[command.Length - 1];
                    lastLineSkipped = false;
                }
            }

            return output;
        }

        public object[] parseCommand(Language language, string commandRaw, bool isInline)
        {
            if (this.isStringSpace(commandRaw))
            {
                return new object[] { "", 0 };
            }

            int colonIndex = commandRaw.IndexOf(":");
            string[] functionArgs;
            string functionName;
            string argumentsRaw;

            // Arguments only exist if there is a colon separating them from the command
            if (colonIndex == -1)
            {
                functionName = this.trimString(commandRaw);
                functionArgs = new string[] { };
            }
            else
            {
                functionName = this.trimString(commandRaw.Substring(0, colonIndex));
                argumentsRaw = this.trimString(commandRaw.Substring(colonIndex + 1));
                functionArgs = this.parseArguments(language, argumentsRaw, isInline);
            }

            return language.print(functionName, functionArgs, isInline);
        }

        public string[] parseArguments(Language language, string argumentsRaw, bool isInline)
        {
            // Directly putting '{' in GLSC code is tough see #79
            char commandStarter = '{';
            int numArgs = 0;
            string[] argumentsConverted;
            string argument;
            char starter;
            int end;
            int i;

            // Until native array pushing is supported, this is required...
            for (i = 0; i < argumentsRaw.Length; i += 1)
            {
                starter = argumentsRaw[i];

                if (this.isCharacterSpace(starter))
                {
                    continue;
                }

                if (this.SearchEnds.ContainsKey(starter))
                {
                    end = this.findSearchEnd(argumentsRaw, starter, i);
                    i += 1;
                }
                else
                {
                    end = this.findNextSpace(argumentsRaw, i);
                }

                if (end == -1)
                {
                    end = argumentsRaw.Length;
                }

                i = end;
                numArgs += 1;
            }

            argumentsConverted = new string[numArgs];
            numArgs = 0;

            for (i = 0; i < argumentsRaw.Length; i += 1)
            {
                starter = argumentsRaw[i];

                if (this.isCharacterSpace(starter))
                {
                    continue;
                }

                if (this.SearchEnds.ContainsKey(starter))
                {
                    end = this.findSearchEnd(argumentsRaw, starter, i);
                    i += 1;
                }
                else
                {
                    end = this.findNextSpace(argumentsRaw, i);
                }

                if (end == -1)
                {
                    end = argumentsRaw.Length;
                }

                argument = argumentsRaw.Substring(i, end - 1);
                i = end;

                if (starter == commandStarter)
                {
                    argument = (string)this.parseCommand(language, argument, true)[0];
                }

                argumentsConverted[numArgs] = argument;
                numArgs += 1;
            }

            return argumentsConverted;
        }


        /*
        Private utilities
        */

        private string generateTabs(int numTabs)
        {
            int numTabsActual = numTabs * 4;
            string output = "";
            int i;

            for (i = 0; i < numTabsActual; i += 1)
            {
                output += " ";
            }

            return output;
        }

        private bool isStringSpace(string text)
        {
            int i;
            for (i = 0; i < text.Length; i += 1)
            {
                if (!this.isCharacterSpace(text[i]))
                {
                    return false;
                }
            }

            return true;
        }

        private bool isCharacterSpace(char character)
        {
            return character == ' ' || character == '\r' || character == '\n';
        }

        private int findNextSpace(string haystack, int start)
        {
            int i;

            for (i = start + 1; i < haystack.Length; i += 1)
            {
                if (this.isCharacterSpace(haystack[i]))
                {
                    return i;
                }
            }

            return haystack.Length;
        }

        private int findSearchEnd(string haystack, char starter, int start)
        {
            char ender = this.SearchEnds[starter];
            int numStarts = 1;
            char current;
            int i;

            for (i = start + 1; i < haystack.Length; i += 1)
            {
                current = haystack[i];

                if (current == starter)
                {
                    numStarts += 1;
                }
                else if (current == ender)
                {
                    numStarts -= 1;
                    if (numStarts < 1)
                    {
                        return i;
                    }
                }
            }

            return -1;
        }

        private string trimString(string text)
        {
            return this.trimStringLeft(this.trimStringRight(text));
        }

        private string trimStringLeft(string text)
        {
            int i;
            for (i = 0; i < text.Length; i += 1)
            {
                if (!this.isCharacterSpace(text[i]))
                {
                    return text.Substring(i);
                }
            }

            return "";
        }

        private string trimStringRight(string text)
        {
            int i;
            for (i = text.Length - 1; i > 0; i += -1)
            {
                if (!this.isCharacterSpace(text[i]))
                {
                    return text.Substring(0, i + 1);
                }
            }

            return "";
        }
    };
}