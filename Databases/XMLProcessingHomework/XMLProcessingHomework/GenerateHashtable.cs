using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;

namespace XMLProcessingHomework
{
    class GenerateHashtable
    {
        public static Hashtable ParseNode(XmlNode node)
        {
            Hashtable ht = new Hashtable();

            foreach (XmlNode n in node.ChildNodes)
            {
                string name = n.Name;
                object value = null;
                
                if (n.HasChildNodes)
                {
                    if (n.ChildNodes.Count > 1) value = (object)ParseNode(n);
                    else
                    {
                        if (n.ChildNodes[0].NodeType == XmlNodeType.Text)
                            value = (object)n.ChildNodes[0].Value;
                        else value = (object)ParseNode(n);
                    }
                }
                else value = (object)n.Value;
                
                if (ht.ContainsKey(name))
                {
                    if (ht[name] is List<Hashtable>)
                    {
                        List<Hashtable> list = (List<Hashtable>)ht[name];
                        list.Add((Hashtable)value);
                        ht[name] = list;
                    }
                    else if (ht[name] is Hashtable)
                    {
                        List<Hashtable> list = new List<Hashtable>();
                        Hashtable htTmp = (Hashtable)ht[name];
                        list.Add(htTmp);
                        list.Add((Hashtable)value);
                        ht[name] = list;
                    }
                }
                else ht.Add(name, value);
            }
            return ht; 
        }
    }
}
