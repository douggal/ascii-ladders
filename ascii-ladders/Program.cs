using System;
using System.Collections.Generic;
using System.Text;

namespace ascii_ladders
{
    // define program exit status codes returned to calling environment.
    enum ExitCodes : int
    {
        Success = 0,
        Error = 1
    };

    // define program limits
    enum LadderLimits : int
    {
        MinSize = 2,
        MaxSize = 15,
        MinWidth = 1,
        MaxWidth = 25
    }

    class Program
    {
        /// <summary>
        /// 1/10/2016 - a programming exercise in C# using Microsoft Visual Studio Community 2015
        /// and GitHub source code version control.  Windows console mode application.
        /// 
        /// Problem was posted on Stack Exchange, Programming Puzzles and Code Golf:
        /// http://codegolf.stackexchange.com/questions/68952/build-ascii-ladders
        /// 
        /// My intent is code the problem as a programming exercise rather
        /// than compress it for code golf.
        /// 
        /// Quote/paraphrase from Stack Exchange:
        /// Given an input of two integers n and m, output an ASCII ladder of length n and size m.
        /// This is an ASCII ladder of length 3 and size 3:
        /// 
        /// o---o
        /// |   |
        /// |   |
        /// |   |
        /// +---+
        /// |   |
        /// |   |
        /// |   |
        /// +---+
        /// |   |
        /// |   |
        /// |   |
        /// o---o
        ///
        /// The length (n) represents how many squares the ladder is made up of.
        /// 
        /// The size (m) represents the width and height of the interior of—that is,
        /// not counting the "borders"—each square.
        /// 
        /// Each square is made up of the interior area filled with spaces,
        /// surrounded by -s on the top and bottom, |s on the left and right, and +s
        /// at all four corners.
        /// 
        /// Borders between squares merge together, so two lines in a row with
        /// +--...--+ merge into one.
        /// 
        /// The corners of the entire ladder are replaced with the character o.
        /// 
        /// You may optionally output a trailing newline.
        /// 
        /// The length of the ladder (n) will always be ≥ 2, and the size (m) will
        /// always be ≥ 1.
        /// 
        /// Input can be taken as a whitespace-/comma-separated string, an
        /// array/list/etc., or two function/command line/etc. arguments.
        /// 
        /// </summary>
        /// <param name="args">Command line arguments.  First is ladder size, and 
        /// second is the height/width of each square.</param>
        static void Main(string[] args)
        {
            Console.WriteLine("ASCII Ladders");

            int n = 0;  // number of squares in the ladder
            int m = 0;  // height and width of the squares

            ExitCodes exit;
            exit = GetCommandLine(args, out n, out m);
            if (exit != ExitCodes.Success)
            {
                Console.WriteLine("Exit with error.  Error code = {0}", (int)exit);
                Console.ReadKey();
                Environment.Exit((int)exit);
            }

            // at this point n and m are clean and ready for use.



            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }

        private static ExitCodes GetCommandLine(string[] args, out int n, out int m)
        {
            // failure to provide command line params and/or invalid params
            // results in program exit.

            // assume success and set error code if one is found.
            ExitCodes exitcode = ExitCodes.Success;

            Console.WriteLine("Number of command line parameters = {0}",
                      args.Length);
            for (int i = 0; i < args.Length; i++)
            {
                Console.WriteLine("Arg[{0}] = [{1}], Typeof = {2}", i, args[i], args[i].GetType().ToString());
            }

            if (args.Length < 2)
            {
                Console.WriteLine("Must supply two small integers: number of squares and height/width.");
                exitcode = ExitCodes.Error;
            }

            bool result;
            result = ConvertToInteger(args[0], out n);
            // TODO future provide specific error code to user.
            if (!result)
            {
                exitcode = ExitCodes.Error;
            }
            else if (result && n > (int)LadderLimits.MaxSize)
            {
                exitcode = ExitCodes.Error;
            }
            else if (result && n < (int)LadderLimits.MinSize)
            {
                exitcode = ExitCodes.Error;
            };

            result = ConvertToInteger(args[1], out m);
            if (!result)
            {
                exitcode = ExitCodes.Error;
            }
            else if (result && m < (int)LadderLimits.MinWidth)
            {
                exitcode = ExitCodes.Error;
            }
            else if (result && m > (int)LadderLimits.MaxWidth)
            {
                exitcode = ExitCodes.Error;
            }

            return exitcode;

        }

        private static bool ConvertToInteger(string arg, out int n)
        {
            bool result = Int32.TryParse(arg, out n);

            // positive integers only please
            if (result && n < 0)
            {
                result = false;
            }

            if (result)
            {
                Console.WriteLine("Converted '{0}' to {1}.", arg, n);
            }
            else
            {
                Console.WriteLine("Attempted conversion of '{0}' failed.",
                                   arg == null ? "<null>" : arg);
            }
            return result;
        }
    }
}
