using FirmaManager.WinFormsClient.Interfaces;

namespace FirmaManager.WinFormsClient
{
    public class NameManipulator : INameManipulator
    {
        public string GetCleanedName(string name)
        {
            name = name.Trim();

            for (int i = 0; i < name.Length - 1; i++)
            {
                if (name[i].ToString() == " " && name[i + 1].ToString() == " " || name[i].ToString() == " " && name[i + 1].ToString() == "-")
                {
                    name = name.Remove(i, 1);
                    i--;
                    continue;
                }

                if (name[i].ToString() == "-" && name[i + 1].ToString() == " ")
                {
                    name = name.Remove(i + 1, 1);
                    i--;
                }
            }

            return name;
        }
    }
}