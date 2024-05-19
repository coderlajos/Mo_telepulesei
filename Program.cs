namespace Mo_telepulesei
{
    internal class Program
    {
        class Telepules 
        { 
            public string Helyseg { get; set; }
            public string Jogallas { get; set; }
            public string Megye { get; set; }
            public string Megyeszekhely { get; set; }
            public int Terulet_ha { get; set; }
            public int Nepesseg { get; set; }
            public int Lakasok_szama { get; private set; }
            public int Iranyitoszam { get; set; }
            public Telepules(string s)
            {
                string[] tmp = s.Split(";");
                Helyseg = tmp[0];
                Jogallas = tmp[1];
                Megye = tmp[2];
                Megyeszekhely = tmp[3];
                Terulet_ha = int.Parse(tmp[4]);
                Nepesseg = int.Parse(tmp[5]);
                Lakasok_szama = int.Parse(tmp[6]);
            }

        }
        class Iranyitoszam
        { 
            public int Irszam { get; set; }
            public string Telepules { get; set; }
            public string Megye { get; set; }
            public Iranyitoszam(string s)
            {
                string[] tmp = s.Split(";");
                Irszam = int.Parse(tmp[0]);
                Telepules = tmp[1];
                Megye = tmp[2];
            }
        }
        
        static void Main(string[] args)
        {
            StreamReader sr_telepules = File.OpenText("telepulesek.txt");
            List<Telepules> telepulesek = new List<Telepules>();
            sr_telepules.ReadLine();
            while(!sr_telepules.EndOfStream) telepulesek.Add(new Telepules(sr_telepules.ReadLine()));
            StreamReader sr_irszam = File.OpenText("irszamok.txt");
            List<Iranyitoszam> iranyitoszamok = new List<Iranyitoszam>();
            sr_irszam.ReadLine();
            while (!sr_irszam.EndOfStream) iranyitoszamok.Add(new Iranyitoszam(sr_irszam.ReadLine()));
            foreach (var i in telepulesek)
            {
                foreach (var j in iranyitoszamok)
                {
                    if (i.Helyseg == j.Telepules)
                    { 
                        i.Iranyitoszam = j.Irszam;
                    }
                }
            }
            StreamWriter sw = new StreamWriter("mo_telepulesei.txt");
            foreach (var i in telepulesek)
            {
                sw.WriteLine($"{i.Helyseg};{i.Jogallas};{i.Megye};{i.Megyeszekhely};{i.Terulet_ha};{i.Nepesseg};{i.Lakasok_szama};{i.Iranyitoszam}");
            }
            sw.Close();
            Console.WriteLine("Kiírás kész!");

        }
    }
}
