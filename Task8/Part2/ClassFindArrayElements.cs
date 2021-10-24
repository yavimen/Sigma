using System.Collections.Generic;

namespace StorageTask.OtherClasses
{
    public delegate bool IsEqual<T>(T p1, T p2);
    class ClassFindArrayElements<T>
    {
        public IsEqual<T> Equal { get;  set; }

        public ClassFindArrayElements(IsEqual<T> equal) 
        {
            Equal = equal;
        }

        public T[] AllSameElemets(T[] collection1, T[] collection2) 
        {
            List<T> sameel = new List<T>();

            for (int i = 0; i < collection1.Length; i++){
                for (int j = 0; j < collection2.Length; j++) { 
                    if (Equal(collection1[i], collection2[j]) && !sameel.Contains(collection1[i]))
                        sameel.Add(collection1[i]); 
                }
            }

            return sameel.ToArray();
        }

        public T[] AllElementsInCol1ThatDifferentFromCol2(T[] collection1, T[] collection2) 
        {
            List<T> difel = new List<T>();

            List<T> secondcollection = new List<T>(collection2);

            for (int i = 0; i < collection1.Length; i++)
            {
                if (!secondcollection.Contains(collection1[i]) && !difel.Contains(collection1[i]))
                    difel.Add(collection1[i]);
            }

            return difel.ToArray();
        }

        public T[] AllDifferentElements(T[] collection1, T[] collection2)
        {
            List<T> difel = new List<T>();

            List<T> c1 = new List<T>(collection1);
            List<T> c2 = new List<T>(collection2);

            for (int i = 0; i < c1.Count; i++)
            {
                if(!c2.Contains(c1[i]) && !difel.Contains(c1[i])) 
                {
                    difel.Add(c1[i]);
                }
            }
            for (int i = 0; i < c2.Count; i++)
            {
                if (!c1.Contains(c2[i]) && !difel.Contains(c2[i]))
                {
                    difel.Add(c2[i]);
                }
            }

            return difel.ToArray();
        }
    }
}
