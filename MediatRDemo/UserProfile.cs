using AutoMapper;
using MediatRDemo.Models;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<CreatingEmployeeRequest, Employee>();
    }
}