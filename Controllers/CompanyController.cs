
using api.Models;
using api.Services;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CompanyController : ControllerBase
    {
        private readonly CompanyService _companyService;
        private readonly ProductService _productService;

        public CompanyController(CompanyService companyService, ProductService productService)
        {
            _companyService = companyService;
            _productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Company>>> GetAllCompanies()
        {
            var companies = await _companyService.GetAllCompaniesAsync();
            return Ok(companies);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Company>> GetCompany(int id)
        {
            var company = await _companyService.GetCompanyByIdAsync(id);
            if (company == null)
            {
                return NotFound();
            }
            return Ok(company);
        }

        [HttpPost]
        public async Task<ActionResult<Company>> CreateCompany(Company company)
        {
            var newId = await _companyService.CreateCompanyAsync(company);
            company.Id = newId;

            return Ok(company);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCompany(int id, Company company)
        {
            if (id != company.Id)
            {
                return BadRequest();
            }

            var success = await _companyService.UpdateCompanyAsync(id, company);
            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompany(int id)
        {
            var success = await _companyService.DeleteCompanyAsync(id);
            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpGet("{companyId}/products")]
        public async Task<ActionResult<IEnumerable<Product>>> GetCompanyProducts(int companyId)
        {
            var products = await _productService.GetProductsByCompanyIdAsync(companyId);
            return Ok(products);
        }

        [HttpPost("{companyId}/products")]
        public async Task<ActionResult<Product>> CreateCompanyProduct(int companyId, Product product)
        {
            var newId = await _productService.CreateProductAsync(companyId, product);
            product.Id = newId;
            product.CompanyId = companyId;

            return Ok(product); 
        }
    }
}