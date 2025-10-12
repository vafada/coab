using Classes;

namespace engine
{
    class FileUtils
    {
        internal static void delete_file(string fileString)
        {
            if (System.IO.File.Exists(fileString))
            {
                System.IO.File.Delete(fileString);
            }
        }


        internal static bool find_and_open_file(out File file_ptr, bool noError, string full_file_name)
        {
            string file_name = System.IO.Path.GetFileName(full_file_name);
            string dir_path = System.IO.Path.GetDirectoryName(full_file_name);

            if (dir_path.Length == 0)
            {
                dir_path = gbl.exe_path;
            }

            bool file_found;

            file_found = System.IO.File.Exists(System.IO.Path.Combine(dir_path, file_name));

            if (file_found == false && noError == false)
            {
                Logging.Logger.Log("Couldn't find " + file_name + ". Check install.");
                seg043.GetInputKey();
            }

            if (file_found == true)
            {
                file_ptr = new File();
                file_ptr.Assign(System.IO.Path.Combine(dir_path, file_name));

                StringRandomIOUtils.Reset(file_ptr);
            }
            else
            {
                file_ptr = null;
            }

            return file_found;
        }


        internal static bool file_find(string filePath)
        {
            return System.IO.File.Exists(filePath);
        }


        static char[] unk_16FA9 = { ' ', '.', '*', ',', '?', '/', '\\', ':', ';', '|' };

        internal static string clean_string(string s)
        {
            string cleanStr = s.Trim(unk_16FA9).ToLower();

            if (cleanStr.Length > 8)
            {
                cleanStr = cleanStr.Substring(0, 8);
            }

            return cleanStr;
        }

        internal static void load_decode_dax(out byte[] out_data, out short decodeSize, int block_id, string file_name)
        {
            seg044.PlaySound(Sound.sound_0);

            out_data = Classes.DaxFiles.DaxCache.LoadDax(file_name.ToLower(), block_id);
            decodeSize = out_data == null ? (short)0 : (short)out_data.Length;
        }
    }
}
