
using AutoMapper;

namespace Diary.Web.Infrastructure
{
    public interface IHaveCustomMappings
    {
        void CreateMappings(IConfiguration configuration);
    }
}
