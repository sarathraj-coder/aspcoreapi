using AutoMapper;
using school.Data;
using school.Model;

namespace school.Configurations
{
    public class AutoMapperConfig : Profile
    {
       public  AutoMapperConfig()
        {
            CreateMap<Student, StudentDTO>().ReverseMap();
            //.AddTransform<String>(n => String.IsNullOrEmpty(n)?"Empty value":"yes value"+n);
            // .ForMember(n => n.Name,opt => opt.MapFrom(n => n.Name))
            // .ForMember(n => n.Address,opt => opt.Ignore());
            //CreateMap<StudentDTO, Student>();
        }
      
    }
}