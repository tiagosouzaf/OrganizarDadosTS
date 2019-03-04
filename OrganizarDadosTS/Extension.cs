using System.Globalization;
using System.IO;
using System.Text;

namespace OrganizarDadosTS
{
    public static class Extension
    {

        public static bool IsNull(this string txt)
        {

            if (string.IsNullOrWhiteSpace(txt))
                return true;


            return false;
        }

        public static string ToLowerAndTrim(this string txt)
        {
            string txtTratado = string.Empty;

            if (txt.IsNull()) return null;

            return txtTratado = txt.ToLower().Trim();
        }

        public static bool DirectoryExists(this string txt)
        {
            if (!Directory.Exists(txt))
                return false;


            return true;
        }

        public static bool DirectoryExists(this DirectoryInfo diretorio)
        {
            if (!diretorio.Exists)
                return false;


            return true;
        }

        public static string RemoverAcentos(this string text)
        {
            var sbReturn = new StringBuilder();
            var arrayText = text.Normalize(NormalizationForm.FormD).ToCharArray();
            foreach (char letter in arrayText)
            {
                if (CharUnicodeInfo.GetUnicodeCategory(letter) != UnicodeCategory.NonSpacingMark)
                    sbReturn.Append(letter);
            }

            return sbReturn.ToString();
        }

        public static string HashPassword(this string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        public static bool Verify(this string password, string hash)
        {
            return BCrypt.Net.BCrypt.Verify(password, hash);
        }

        public static bool EhPar(this int numero)
        {

            if (numero % 2 == 0)
                return true;

            return false;
        }
    }
}
