using storyshare_dotNet_backend.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;     // for route and http attributes
using System.Linq;                  // for IEnumerable interface

namespace storyshare_dotNet_backend.Controllers
{
  [Route("stories")]  // The Controller handles routes for /stories
  public class StoriesController
  {
    // declare property to hold database context
    private readonly StoryContext stories;

    // constructor to receive database context via DI
    public StoriesController(StoryContext storiesCtx){
      stories = storiesCtx;
    }

    // INDEX
    [HttpGet] // get requrest to "/stories"
    public IEnumerable<Story> index(){
      // returns all stories
      return stories.Stories.ToList();
    }

    // CREATE
    [HttpPost]  // post request to "/stories"
    public IEnumerable<Story> Post([FromBody]Story Story){
      // add story
      stories.Stories.Add(Story);
      // save changes
      stories.SaveChanges();
      // return all stories
      return stories.Stories.ToList();
    }

    // READ SINGLE
    [HttpGet("{id}")] // get request to "stories/{id}"
    public Story show(long id){
      return stories.Stories.FirstOrDefault(story => story.id == id);
    }

    // UPDATE
    [HttpPut("{id}")]
    public IEnumerable<Story> update([FromBody]Story Story, long id){
      // retrieve story to be updated
      Story oldStory = stories.Stories.FirstOrDefault(story => story.id == id);
      // update stories properties
      oldStory.title = Story.title;
      oldStory.author = Story.author;
      oldStory.story = Story.story;
      // save changes
      stories.SaveChanges();
      // returns updated list of stories
      return stories.Stories.ToList();
    }

    // DELETE
    [HttpDelete("{id}")]
    public IEnumerable<Story> destroy(long id){
      // retrieve existing story
      Story oldStory = stories.Stories.FirstOrDefault(story => story.id == id);
      // remove story from db
      stories.Stories.Remove(oldStory);
      // save changes
      stories.SaveChanges();
      // return updated list of stories
      return stories.Stories.ToList();
    }
  }
}
