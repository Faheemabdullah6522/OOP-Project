using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using Window_Forms.Models;
using Window_Forms.Repositories;

namespace Window_Forms.Services
{
    /// <summary>
    /// Service to manage student operations
    /// Demonstrates separation of concerns
    /// </summary>
    public class StudentService
    {
        private readonly StudentRepository _repository = new StudentRepository();

        /// <summary>
        /// Get or create student by email
        /// </summary>
        public Student GetOrCreateStudent(string email, int userId = 0)
        {
            try
            {
                var student = _repository.GetByEmail(email);
                if (student != null)
                    return student;

                // Create new student record
                var newStudent = new Student
                {
                    Email = email,
                    UserId = userId,
                    CreatedAt = DateTime.Now
                };

                _repository.Add(newStudent);
                return newStudent;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting or creating student: {ex.Message}");
            }
        }

        /// <summary>
        /// Update student profile
        /// </summary>
        public bool UpdateStudentProfile(Student student)
        {
            try
            {
                if (!student.ValidateBasicInfo())
                    throw new Exception("Invalid student data");

                _repository.Update(student);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error updating student profile: {ex.Message}");
            }
        }

        /// <summary>
        /// Get all students in department
        /// </summary>
        public List<Student> GetStudentsByDepartment(string department)
        {
            try
            {
                return new List<Student>(_repository.GetByDepartment(department));
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving students: {ex.Message}");
            }
        }

        /// <summary>
        /// Get eligible students for scholarship
        /// </summary>
        public List<Student> GetEligibleStudents(decimal minCGPA)
        {
            try
            {
                return new List<Student>(_repository.GetByMinimumCGPA(minCGPA));
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving eligible students: {ex.Message}");
            }
        }

        /// <summary>
        /// Calculate student's scholarship score
        /// </summary>
        public decimal CalculateScholarshipScore(Student student)
        {
            try
            {
                decimal score = 0;

                // CGPA: 0-4 (weighted 50%)
                if (student.CGPA.HasValue)
                    score += (student.CGPA.Value / 4) * 50;

                // Family Income: Lower income = Higher score (weighted 30%)
                if (student.FamilyIncome.HasValue)
                {
                    decimal incomeScore = Math.Max(0, 1 - (student.FamilyIncome.Value / 500000));
                    score += incomeScore * 30;
                }

                // Academic Progress: Based on average percentage (weighted 20%)
                decimal avgPercentage = student.GetAveragePercentage();
                score += (avgPercentage / 100) * 20;

                return Math.Round(score, 2);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error calculating scholarship score: {ex.Message}");
            }
        }
    }
}
