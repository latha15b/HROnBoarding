using System;
using System.Collections.Generic;
using System.Linq;
using OnBoardingAPI.Models;

namespace OnBoardingAPI.Data
{
    public class SqlPersonalDetailsRepo : IPersonalDetailsRepo
    {
        private readonly OnBoardingContext _context;
        public SqlPersonalDetailsRepo(OnBoardingContext context)
        {
            _context = context;
        }

        public void CreatePersonalDetails(PersonalDetails personalDetails)
        {
            if(personalDetails == null)
            {
                throw new ArgumentNullException(nameof(personalDetails));
            }

            _context.PersonalDetails.Add(personalDetails);
        }

        public void DeletePersonalDetails(PersonalDetails personalDetails)
        {
            if(personalDetails == null)
            {
                throw new ArgumentNullException(nameof(personalDetails));
            }

            _context.PersonalDetails.Remove(personalDetails);
        }

        public IEnumerable<State> GetAllStateDetails()
        {
            return _context.State.ToList().OrderBy(state => state.StateName);
        }

        public IEnumerable<PersonalDetails> GetAllPersonalDetails()
        {
            return _context.PersonalDetails.ToList();
        }

        public IEnumerable<City> GetAllCityDetails(int stateId)
        {
            return _context.City.Where(city => city.StateId == stateId).ToList().
            OrderBy(order => order.CityName);
        }

        public IEnumerable<City> GetAllCityDetailsByStateName(string stateName)
        {
             var stateId =  _context.State.Where(st => 
            st.StateName == stateName).Select(emp => emp.StateId).FirstOrDefault();
            return _context.City.Where(city => city.StateId == stateId).ToList().
            OrderBy(order => order.CityName);
        }

        public PersonalDetails GetPersonalDetailsById(int employeeId)
        {
            return _context.PersonalDetails.FirstOrDefault(emp => emp.EmployeeId == employeeId);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0); 
        }

        public void UpdatePersonalDetails(PersonalDetails personalDetails)
        {
            //Nothing
        }

    }
}