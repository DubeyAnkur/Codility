using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Codility._2021
{
    public class TheDoge
    {
        public class Pet
        {
            public int Type;
            public int Toy;
            public List<Pet> Childs;
            public bool Traversed = false;

            public Pet(int type, int toy)
            {
                Type = type;
                Toy = toy;
                Childs = new List<Pet>();
            }

        }

        public class State
        {
            public int dogCount = 0;
            public int dogToyCount = 0;
            public int catCount = 0;
            public int catToyCount = 0;
        }

        public bool solution(int[] P, int[] T, int[] A, int[] B)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)
            bool ret = true;
            var pets = new Pet[P.Length];

            for (int i = 0; i < P.Length; i++)
            {
                var temp = new Pet(P[i], T[i]);
                pets[i] = temp;
            }

            for (int i = 0; i < A.Length; i++)
            {
                pets[A[i]].Childs.Add(pets[B[i]]);
                pets[B[i]].Childs.Add(pets[A[i]]);
            }

            for (int i = 0; i < pets.Length; i++)
            {
                if (pets[i].Traversed == false)
                {
                    var state = new State();
                    RecursiveDFS(pets[i], state);

                    if (state.dogCount != state.dogToyCount || state.catCount != state.catToyCount)
                        return false;
                }
            }

            return ret;

        }

        private void RecursiveDFS(Pet pet, State state)
        {
            if (pet.Traversed == false)
            {
                if (pet.Type == 1)
                    state.dogCount++;
                else
                    state.catCount++;

                if (pet.Toy == 1)
                    state.dogToyCount++;
                else
                    state.catToyCount++;

                pet.Traversed = true;
                foreach (Pet pChild in pet.Childs)
                    RecursiveDFS(pChild, state);
            }

        }
    }
}
