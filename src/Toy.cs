using System.ComponentModel.DataAnnotations;
using Aspenlaub.Net.GitHub.CSharp.Pegh.Interfaces;

namespace Aspenlaub.Net.GitHub.CSharp.DotNetEfToy;

public class Toy : IGuid {
    [Key]
    public string Guid { get; set; }

    public string Name { get; set; }

    public Toy() {
        Guid = System.Guid.NewGuid().ToString();
        Name = "This is the name of test object " + Guid;
    }
}