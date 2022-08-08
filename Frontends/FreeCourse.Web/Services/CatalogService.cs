using FreeCourse.Web.Models;
using FreeCourse.Web.Models.Catalogs;
using FreeCourse.Web.Services.Interfaces;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace FreeCourse.Web.Services
{
    public class CatalogService : ICatalogService
    {
        private readonly HttpClient _httpClient;

        public CatalogService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task<bool> CreateCourseAsync(CourseCreateInput courseCreateInput)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> DeleteCourseAsync(string courseId)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<CategoryViewModel>> GetAllCategoryAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<List<CourseViewModel>> GetAllCourseAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<List<CourseViewModel>> GetAllCourseByUserIdAsync(string userId)
        {
            throw new System.NotImplementedException();
        }

        public Task<CourseViewModel> GetByCourseIdAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> UpdateCourseAsync(CourseUpdateInput courseUpdateInput)
        {
            throw new System.NotImplementedException();
        }
    }
}
