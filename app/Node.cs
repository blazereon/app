public class Node
{
    public int Id { get; set; }
    public Dictionary<int, List<string>> Attributes { get; set; }
    public List<Node> Neighbors { get; set; }

    public Node(int id)
    {
        Id = id;
        Attributes = new Dictionary<int, List<string>>();
        Neighbors = new List<Node>();
    }

    public void AddNeighbor(Node neighbor)
    {
        if (!Neighbors.Contains(neighbor))
        {
            Neighbors.Add(neighbor);
            neighbor.Neighbors.Add(this);  // Ensure bidirectional connection
        }
    }
}