using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstNewDatabaseSample{
  class Program{
    static void Main( string[] args ){
      using( var db = new BlogContext( ) ){
        Console.Write( "Enter name for a new blog: " );
        var name = Console.ReadLine( );

        Console.WriteLine( name );

        var blog = new Blog{ Name = name };
        Console.WriteLine( blog.Name + "from blog" );
        db.Blogs.Add( blog );
        db.SaveChanges( );

        var query = from b in db.Blogs
                    orderby b.Name
                    select b;

        Console.WriteLine( "All blogs in the database: " );

        foreach( var bl in query ){
          Console.WriteLine( bl.Name );
        }

        Console.WriteLine( "Press any key to exit... " );
        Console.ReadKey( );
      }
    }
  }

  public class Blog{
    public int BlogId { get; set; }
    public string Name { get; set; }

    public virtual List<Post> Posts { get; set; }
  }

  public class Post{
    public int Postid { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }

    public int BlogId { get; set; }

    //virtual is used so that EF can do lazzy loading
    public virtual Blog Blog { get; set; }
  }

  //rappresets a session with the database and enables to query and save data
  public class BlogContext: DbContext{
    //allows to save and query intances of the type defined in DbSet
    public DbSet<Blog> Blogs { get; set; }

    public DbSet<Post> Posts { get; set; }
  }
}