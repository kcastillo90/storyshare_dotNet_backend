using storyshare_dotNet_backend.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;     // for route and http attributes
using System.Linq;                  // for IEnumerable interface

namespace storyshare_dotNet_backend.Controllers
{
  [Route("stories")]  // The Controller handles routes for /stories
  public class FirstController : Controller
  {
    // route matches /first/first
    public Hashtable First(){
      return new Hashtable(){"Result", "You made a Route"};
    }
  }
}
