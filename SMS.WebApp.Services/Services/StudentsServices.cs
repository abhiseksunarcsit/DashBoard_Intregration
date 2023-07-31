using SMS.WebApp.Core.IRepositories;
using SMS.WebApp.Data.Healper;
using SMS.WebApp.Data.Models.DataModels;
using SMS.WebApp.Data.Models.ViewModels;
using SMS.WebApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.WebApp.Services.Services
{
    public class StudentsServices:IStudentsServices
    {
        private readonly IStudentsRepositories _repo;
        public StudentsServices(IStudentsRepositories repo)
        {
            _repo = repo;

        }

        public async Task<DataResult> CreateStudents(StudentViewModel studentArgs)
        {
            Students stu = new Students
            {
                FirstName = studentArgs.FirstName,
                LastName = studentArgs.LastName,
                DOB = studentArgs.DOB,
                gender = studentArgs.Gender,
                PhoneNumber = studentArgs.PhoneNumber,
                GradeLevel = studentArgs.GradeLevel,
                CreateUserName="",
                CreateDate = DateTime.UtcNow,
                IsDeleted = false,
                UpdateUserName = null,
                UpdatedDate = DateTime.Now,
               
            };
            var result = await _repo.CreateStudents(stu);  
            return result;
        }

        public async Task<DataResult> DeleteStudents(Guid studentId)
        {
            var result = await _repo.DeleteStudents(studentId);
            return result;
        }

        public async Task<DataResult<StudentViewModel>> GetAllStudents()
        {
            //ekuta type ko datatype lai arko type ko return ma change gareko (Whole process) student type bata studentviewmodel type ma change gareko
            //Define return type variable
            DataResult<StudentViewModel> result = new DataResult<StudentViewModel>();
            //get data from students repository
            var response = await _repo.GetAllStudents();
            //Assign value to define return variable ("result") from repository response
            result.Success = response.Success;
            result.Message = response.Message;
            //map data from students datamodel to studentsviewmodel
            result.Data= response.Data.Select(s=>new StudentViewModel
            {
                FirstName=s.FirstName,
            }).ToList();
            return result;
            
        }

        public  async Task<DataResult> UpdateStudents(StudentViewModel studentArgs)
        {
            Students stu = new Students
            {
                FirstName = studentArgs.FirstName,
                LastName = studentArgs.LastName,
                DOB = studentArgs.DOB,
                gender = studentArgs.Gender,
                PhoneNumber = studentArgs.PhoneNumber,
                GradeLevel = studentArgs.GradeLevel,
                CreateUserName = "",
                CreateDate = DateTime.UtcNow,
                IsDeleted = false,
                UpdateUserName = null,
                UpdatedDate = DateTime.Now,

            };
            var result = await _repo.UpdateStudents(stu);
            return result;
        }
    

       
    }
}
