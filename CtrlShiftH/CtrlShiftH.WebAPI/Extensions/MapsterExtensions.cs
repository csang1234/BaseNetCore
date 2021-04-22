using Mapster;
using Microsoft.AspNetCore.Builder;

namespace CtrlShiftH.Extensions
{
    public static class MapsterExtensions
    {
        public static void UseMapsterConfig(this IApplicationBuilder app)
        {
            TypeAdapterConfig.GlobalSettings.AllowImplicitDestinationInheritance = true;
            //#region Assign
            //TypeAdapterConfig.GlobalSettings.ForType<Examination, AssignWithCodeOnlyViewModel>()
            //                                    .Map(dest => dest.Code, src => src.ExaminationDetails.FirstOrDefault().Code)
            //                                    .Map(dest => dest.PersonId, src => src.PersonId)
            //                                    .Map(dest => dest.PersonName, src => src.Person.Name)
            //                                    .Map(dest => dest.Unit, src => src.Unit)
            //                                    .Map(dest => dest.ExamId, src => src.Id)
            //;
        }
    }
}