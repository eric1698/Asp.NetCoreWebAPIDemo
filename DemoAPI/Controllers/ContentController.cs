using BLL.interfaces;
using Microsoft.AspNetCore.Mvc;
using Model.ViewModels;
using System.Threading.Tasks;

namespace DemoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContentController : ControllerBase
    {
        // GET api/values
        IContentBLL ContentBLL;
        public ContentController(IContentBLL contentBLL)
        {
            ContentBLL = contentBLL;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {           
            var result = await ContentBLL.Read();
            return Ok(result);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return id.ToString();
        }

        // POST api/values
        [HttpPost]
        public async Task<ActionResult> Post([FromBody]ContentCreateViewModel viewModel)
        {           
            string msg = string.Empty;
            if (await ContentBLL.Inert(viewModel))
                msg = "新增成功";
            else
                msg = "新增失敗";
            return Ok(new {ret = msg });
        }

        // PUT api/values/5
        [HttpPut]
        public async Task<ActionResult> Put(ContentUpdateViewModel viewModel)
        {
            string msg = string.Empty;
            if (await ContentBLL.Update(viewModel))
                msg = "更新成功";
            else
                msg = "更新失敗";
            return Ok(new { ret= msg});
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            string msg = string.Empty;
            if (await ContentBLL.Delete(id))
                msg = "刪除成功";
            else
                msg = "刪除失敗";
            return Ok(new { ret = msg });
        }
    }
}
