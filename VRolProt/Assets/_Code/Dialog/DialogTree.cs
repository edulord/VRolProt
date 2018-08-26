using System.Collections.Generic;

public class DialogTree
{
    internal const char SEPARATOR = '⌂';
    public DialogNode Root;
    public int DialogKey;

    public string AsString()
    {
        return DialogKey + SEPARATOR + AsString(Root, "");
    }
    public string AsString(DialogNode node, string partial)
    {
        partial += node.AsString() + SEPARATOR;

        foreach (var child in node.children)
            AsString(child, partial);

        return partial;
    }

    private static DialogTree FromString(string data)
    {
        var parts = data.Split(SEPARATOR);
        var dict = new Dictionary<int, DialogNode>();

        var res = new DialogTree
        {
            DialogKey = int.Parse(parts[0])
        };

        bool first = true;
        foreach(var nodeData in parts)
        {
            if (first) // Para saltarme el primer tramo que es el que tiene la 'DialogKey'
            {
                first = false;
                continue;
            }
            var node = DialogNode.FromString(nodeData);
            if (node.DialogId == 0)
                res.Root = node;
            else
            {
                node.parent = dict[node.ParentId];
                node.parent.children.Add(node);
            }

            dict.Add(node.DialogId, node);
        }
        return res;
    }
}

public class DialogNode
{
    private const char SEPARATOR = '~';
    /// <summary>
    /// Puntero al nodo padre.
    /// </summary>
    public DialogNode parent;

    /// <summary>
    /// Identificador de nodo dentro del árbol.
    /// </summary>
    public int DialogId;

    /// <summary>
    /// Identficador del nodo padre.
    /// </summary>
    public int ParentId;

    /// <summary>
    /// Lista con los nodos hijos.
    /// </summary>
    public List<DialogNode> children = new List<DialogNode>();

    /// <summary>
    /// El texto asociado al mensaje.
    /// </summary>
    public string Text;

    /// <summary>
    /// Especifica el nombre del personaje que emite el texto.
    /// </summary>
    public string Owner;

    /// <summary>
    /// Indica si es texto enunciativo, narrativo, una elección...
    /// </summary>
    public int DialogType;

    /// <summary>
    /// Indica el humor asociado al texto.
    /// </summary>
    public int Mood;

    /// <summary>
    /// Indica la velocidad a la que se presentará el texto.
    /// </summary>
    public int Speed;

    internal string AsString()
    {
        return Text + SEPARATOR + Owner + SEPARATOR + DialogType + SEPARATOR + Mood + SEPARATOR + Speed + SEPARATOR + DialogId;
    }

    internal static DialogNode FromString(string data)
    {
        var parts = data.Split(SEPARATOR);

        return new DialogNode
        {
            Text = parts[0],
            Owner = parts[1],
            DialogType = int.Parse(parts[2]),
            Mood = int.Parse(parts[3]),
            Speed = int.Parse(parts[4]),
            DialogId = int.Parse(parts[5]),
            ParentId = int.Parse(parts[6]),
        };
    }
}
