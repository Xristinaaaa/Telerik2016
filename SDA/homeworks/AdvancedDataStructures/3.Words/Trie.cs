using System;
using System.Collections.Generic;

namespace _3.Words
{
    public class Trie
    {
        private Node root;

        public Trie()
        {
            this.root = new Node("");
        }

        public void AddWord(string word)
        {
            this.InnerAddWord(word, this.root);
        }

        private void InnerAddWord(string wordSubString, Node element)
        {
            if (string.IsNullOrEmpty(wordSubString) || string.IsNullOrWhiteSpace(wordSubString))
            {
                element.Occurances++;
                return;
            }

            var currentChar = wordSubString[0].ToString();

            if (!element.Children.ContainsKey(currentChar))
            {
                element.Children.Add(currentChar, new Node(currentChar) { Parent = element });
            }

            this.InnerAddWord(wordSubString.Substring(1), element.Children[currentChar]);
        }

        public bool TryFindWord(string word, out int occurances)
        {
            return this.InnerTryFindWord(word, out occurances, root);
        }

        private bool InnerTryFindWord(string wordSubString, out int occurances, Node element)
        {
            if (string.IsNullOrEmpty(wordSubString) || string.IsNullOrWhiteSpace(wordSubString))
            {
                occurances = element.Occurances;
                return true;
            }

            var currChar = wordSubString[0].ToString();

            if (!element.Children.ContainsKey(currChar))
            {
                occurances = 0;
                return false;
            }

            return this.InnerTryFindWord(wordSubString.Substring(1), out occurances, element.Children[currChar]);
        }

        private class Node
        {
            public Node(string value, int occurs = 0)
            {
                this.Children = new Dictionary<string, Node>();
                this.Value = value;
                this.Occurances = occurs;
            }
            public string Value { get; set; }

            public int Occurances { get; set; }

            public Dictionary<string, Node> Children { get; set; }

            public Node Parent { get; set; }

            public override int GetHashCode()
            {
                return this.Value.GetHashCode();
            }

            public override bool Equals(object obj)
            {
                var objAsNode = obj as Node;

                if (objAsNode == null)
                {
                    return false;
                }

                return this.Value.Equals(objAsNode.Value);
            }
        }
    }
}
