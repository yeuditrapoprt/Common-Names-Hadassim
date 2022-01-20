using ReadFrmoFile;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First
{
    class Program
    {
        //....//
        static readonly string textFile = @"C:\Users\רפפורט\Desktop\yeudit.txt";
        static Dictionary<string, int> namesValues = new Dictionary<string, int>();//key=Jacob,value=15
        static Dictionary<string, int> mapsNameLocation = new Dictionary<string, int>();//key=Jacob,value=1
        static List<NamesPairs> namesSynonyms = new List<NamesPairs>();//{Jacob, Yaakov},{Yaakov, Yaacov}
        static int ID = 1;
        public static void ReadFromFile()
        {
            if (File.Exists(textFile))
            {
                // Read file using StreamReader. Reads file line by line  
                using (StreamReader file = new StreamReader(textFile))
                {
                    string ln;
                    while ((ln = file.ReadLine()) != "Synonyms")
                    {
                        namesValues.Add(ln.Substring(0, ln.IndexOf(" ")), int.Parse(ln.Substring(ln.IndexOf(" ") + 1)));
                    }
                    while ((ln = file.ReadLine()) != null)
                    {
                        namesSynonyms.Add(new NamesPairs(ln.Substring(0, ln.IndexOf(",")), ln.Substring(ln.IndexOf(",") + 1)));
                        if (!mapsNameLocation.Keys.Contains(ln.Substring(0, ln.IndexOf(","))))
                            mapsNameLocation.Add(ln.Substring(0, ln.IndexOf(",")), ID++);
                        if (!mapsNameLocation.Keys.Contains(ln.Substring(ln.IndexOf(",") + 1)))
                            mapsNameLocation.Add(ln.Substring(ln.IndexOf(",") + 1), ID++);
                    }
                    file.Close();
                }
            }
            foreach (var keyValue in namesValues)
            {
                if (!mapsNameLocation.Keys.Contains(keyValue.Key))
                    mapsNameLocation.Add(keyValue.Key, ID++);
            }
        }
        public static void UnionSynonymsNames(Set set)
        {
            foreach (var namePair in namesSynonyms)//{Jacob, Yaakov}
            {
                //check if thee in the popular names
                if (namesValues.Keys.Contains(namePair.name2) || namesValues.Keys.Contains(namePair.name1))
                    set.Union(mapsNameLocation[namePair.name2], mapsNameLocation[namePair.name1]);
            }
        }
        public static void InitNamesValuesLocat(NameValue[] namesValuesByLoca)
        {
            foreach (var keyValue in namesValues)//[key=Jacob,value=15]=1
            {
                namesValuesByLoca[mapsNameLocation[keyValue.Key]] = new NameValue(keyValue.Key, keyValue.Value);
            }
        }
        public static void PrintNamesValues(NameValue[] namesValuesByLocations, Set set)
        {
            Console.Write("Output: ");
            for (int i = 0; i < namesValuesByLocations.Length; i++)
            {
                //מקרה קצה של בן שלא נמצא ברשימה הנפוצה
                if (namesValuesByLocations[i] != null && (i == set.FindImmidiateParent(i)|| namesValuesByLocations[set.FindImmidiateParent(i)]==null))
                {
                    Console.Write(namesValuesByLocations[i].Name + "(" + namesValuesByLocations[i].Value + ") ,");
                }
            }
            Console.WriteLine();
        }
        public static void SumValuesParents(NameValue[] namesValuesByLocat, Set set)
        {
            for (int i = 0; i < namesValuesByLocat.Length; i++)//{1,2,3,4,5,6,7}
            {
                if (namesValuesByLocat[i] != null && i != set.FindImmidiateParent(i) && namesValuesByLocat[set.FindImmidiateParent(i)] != null)
                {
                    if (set.FindImmidiateParent(i) < namesValuesByLocat.Length)
                        namesValuesByLocat[set.FindImmidiateParent(i)].Value += namesValuesByLocat[i].Value;
                }
            }
        }
        static void Main(string[] args)
        {
            //read the details
            ReadFromFile();
            //key=name value = index in the array          
            NameValue[] namesValuesByLocat = new NameValue[namesValues.Count() + 3];
            //just a bigger number than highest value of vertices
            Set set = new Set(namesValues.Count() + 3);
            //locate eatch name and value in its id place 
            InitNamesValuesLocat(namesValuesByLocat);
            //unions the groups
            UnionSynonymsNames(set);
            //sum the values in the parent locations
            SumValuesParents(namesValuesByLocat, set);
            //print
            PrintNamesValues(namesValuesByLocat, set);
        }
    }
}