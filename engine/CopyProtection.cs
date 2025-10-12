using Classes;

namespace engine
{
    class CopyProtection
    {
        static string[] codeWheel = { 
								 "CWLNRTESSCEDCSHSISERRRNSHSSTSSNNHSHN",
								 "LAASRDAIILIDSUGADAEEOEGRLSELIITESOIO",
								 "LRUNIMMORIIGRRIUPTIIUELIMLHMIXACGRIL",
								 "Z0LIOHEUVNODSGEOGXYWISIOCRARLRARRHOI",
								 "AMTELRLUIYNAEOOITOUELRREREUIMADPPFAB",
								 "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890"
							 };

        internal static void copy_protection()
        {
            string code_path_str;
            char input_expected;
            char input_key;

            ovr034.Load24x24Set(0x1A, 0, 1, "tiles");
            ovr034.Load24x24Set(0x16, 0x1A, 2, "tiles");

            FrameRenderer.DrawFrame_Outer();

            TextRenderer.displayString("Align the espruar and dethek runes", 0, 10, 2, 3);
            TextRenderer.displayString("shown below, on translation wheel", 0, 10, 3, 3);
            TextRenderer.displayString("like this:", 0, 10, 4, 3);
            int attempt = 0;

            do
            {

                int var_6 = StringRandomIOUtils.Random(26);
                int var_7 = StringRandomIOUtils.Random(22);

                ovr034.DrawIsoTile(var_6, 3, 0x11);
                ovr034.DrawIsoTile(var_7 + 0x1a, 7, 0x11);

                int code_path = StringRandomIOUtils.Random(3);

                switch (code_path)
                {
                    case 0:
                        code_path_str = "-..-..-..";
                        break;

                    case 1:
                        code_path_str = "- - - - -";
                        break;

                    case 2:
                        code_path_str = ".........";
                        break;

                    default:
                        code_path_str = string.Empty;
                        break;
                }

                int code_row = StringRandomIOUtils.Random(6);

                string text = "Type the character in box number " + (6 - code_row);

                TextRenderer.displayString(text, 0, 10, 12, 3);

                TextRenderer.displayString("under the ", 0, 10, 13, 3);
                TextRenderer.displayString(code_path_str, 0, 15, 13, 14);
                TextRenderer.displayString("path.", 0, 10, 13, 0x19);

                int code_index = var_6 + 0x22 - var_7 + (code_path * 12) + ((5 - code_row) << 1);

                while (code_index < 0)
                {
                    code_index += 36;
                }

                while (code_index > 35)
                {
                    code_index -= 36;
                }

                input_expected = codeWheel[code_row][code_index];

                string input = TextRenderer.getUserInputString(1, 0, 13, "type character and press return: ");

                input_key = (input == null || input.Length == 0) ? ' ' : input[0];
                attempt++;

                if (input_key != input_expected)
                {
                    TextRenderer.DisplayStatusText(0, 14, "Sorry, that's incorrect.");
                }
                else
                {
                    return;
                }
            } while (input_key != input_expected && attempt < 3);

            if (attempt >= 3)
            {
                seg044.PlaySound(Sound.sound_1);
                seg044.PlaySound(Sound.sound_5);
                gbl.game_speed_var = 9;
                TextRenderer.DisplayStatusText(0, 14, "An unseen force hurls you into the abyss!");
                KeyInputQueue.SysDelay(0x3E8);
                seg043.print_and_exit();
            }
        }
    }
}
