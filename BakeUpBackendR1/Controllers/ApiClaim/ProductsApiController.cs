using BakeUpBackendR1.Models.Claim;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace BakeUpBackendR1.Controllers.ApiClaim
{
    public class ProductsApiController : BaseApiController
    {
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        private string GetProducts(int? id=null)
        {
            if(id==null)
                return $"{ComposeBaseUrl()}Products";
            else
                return $"{ComposeBaseUrl()}Products?where=id={id}&strip_description=1";
        }
        private string GetCategories(int? id=null)
        {
            if(id==null)
                return $"{ComposeBaseUrl()}Categories";
            else
                return $"{ComposeBaseUrl()}Categories?where=id={id}&strip_description=1";
        }
        private string GetChildCategories(int parentId)
        {
                return $"{ComposeBaseUrl()}Categories?where=parent_id={parentId}";
        }
        private string GetProductsInCat(int catId)
        {
            return $"{ComposeBaseUrl()}Products?where=category_id={catId}";
        }

        // GET api/<controller>/5
        [Route("apiclaim/productsapi/products")]
        public async Task<IEnumerable<ProductModel>> GetProductsAsync()
        {
            var res = await CallClaimAsync<ProductModel>(GetProducts());
            return res;
        }
        [Route("apiclaim/productsapi/product/{id}")]
        public async Task<ProductModel> GetProductAsync(int id)
        {
            var res= await CallClaimAsync<ProductModel>(GetProducts(id));
            return res.FirstOrDefault();
        }

        //[Route("apiclaim/productsapi/categories")]
        public async Task<IEnumerable<CategoryModel>> GetChildCategoriesAsync(int parentId)
        {
            var res = await CallClaimAsync<CategoryModel>(GetChildCategories(parentId));
            return res;
        }
        [Route("apiclaim/productsapi/categories")]
        public async Task<IEnumerable<CategoryModel>> GetCategoriesAsync()
        {

            var res = await CallClaimAsync<CategoryModel>(GetCategories());
            return res;
        }
        [Route("apiclaim/productsapi/categories/{id}")]
        public async Task<CategoryModel> GetCategoryAsync(int id)
        {

            var res = await CallClaimAsync<CategoryModel>(GetCategories(id));
            return res.FirstOrDefault();
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}