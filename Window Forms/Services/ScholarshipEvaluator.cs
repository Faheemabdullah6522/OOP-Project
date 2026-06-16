using System;
using System.Collections.Generic;
using Window_Forms.Models;

namespace Window_Forms.Services
{
    /// <summary>
    /// Service class to evaluate scholarship eligibility
    /// Demonstrates single responsibility principle
    /// </summary>
    public class ScholarshipEvaluator
    {
        /// <summary>
        /// Evaluate if student is eligible for scholarship
        /// </summary>
        public ScholarshipEvaluationResult Evaluate(Student student, Scholarship scholarship)
        {
            if (student == null || scholarship == null)
                return new ScholarshipEvaluationResult(false, "Invalid student or scholarship", 3);

            var matches = new List<string>();
            var blockers = new List<string>();

            // Check CGPA requirement
            if (scholarship.MinimumCGPA.HasValue)
            {
                if (!student.CGPA.HasValue)
                    blockers.Add($"CGPA is missing from your profile");
                else if (student.CGPA < scholarship.MinimumCGPA)
                    blockers.Add($"CGPA must be at least {scholarship.MinimumCGPA:0.00}, yours is {student.CGPA:0.00}");
                else
                    matches.Add($"CGPA {student.CGPA:0.00} meets the requirement of {scholarship.MinimumCGPA:0.00}");
            }

            // Check Family Income requirement
            if (scholarship.MaxFamilyIncome.HasValue)
            {
                if (!student.FamilyIncome.HasValue)
                    blockers.Add("Family income is missing from your profile");
                else if (student.FamilyIncome > scholarship.MaxFamilyIncome)
                    blockers.Add($"Family income must be at most {scholarship.MaxFamilyIncome:0}, yours is {student.FamilyIncome:0}");
                else
                    matches.Add($"Income {student.FamilyIncome:0} is within the required limit");
            }

            // Check Degree Program requirement
            if (!string.IsNullOrEmpty(scholarship.DegreeProgram))
            {
                if (ProgramMatches(scholarship.DegreeProgram, student.DegreeProgram))
                    matches.Add($"Degree program '{student.DegreeProgram}' matches requirement");
                else
                    blockers.Add($"Degree program must be {scholarship.DegreeProgram}");
            }

            // Check Semester/Year requirement
            if (!string.IsNullOrEmpty(scholarship.SemesterYear))
            {
                if (TextMatches(scholarship.SemesterYear, student.SemesterYear))
                    matches.Add($"Semester/Year matches requirement");
                else
                    blockers.Add($"Semester/Year should match {scholarship.SemesterYear}");
            }

            // Check Need-Based requirement
            if (scholarship.NeedBased && student.FamilyIncome.HasValue)
            {
                if (student.FamilyIncome <= 100000)
                    matches.Add("Income qualifies for need-based scholarship");
                else
                    blockers.Add("Family income exceeds need-based limit");
            }

            if (blockers.Count > 0)
                return new ScholarshipEvaluationResult(false, "Not eligible", string.Join("; ", blockers), 2);

            if (matches.Count > 0)
                return new ScholarshipEvaluationResult(true, "Recommended", string.Join("; ", matches), 0);

            return new ScholarshipEvaluationResult(true, "Eligible", "No specific restrictions found", 1);
        }

        /// <summary>
        /// Check if program matches
        /// </summary>
        private bool ProgramMatches(string required, string actual)
        {
            if (string.IsNullOrEmpty(required))
                return true;
            if (string.IsNullOrEmpty(actual))
                return false;

            string req = required.Trim().ToLowerInvariant();
            string act = actual.Trim().ToLowerInvariant();
            return act.Contains(req) || req.Contains(act);
        }

        /// <summary>
        /// Check if text matches
        /// </summary>
        private bool TextMatches(string required, string actual)
        {
            return ProgramMatches(required, actual);
        }
    }

    /// <summary>
    /// Result of scholarship evaluation
    /// </summary>
    public class ScholarshipEvaluationResult
    {
        public bool IsEligible { get; }
        public string Label { get; }
        public string Reason { get; }
        public int Rank { get; }  // 0=Recommended, 1=Eligible, 2=Not Eligible, 3=Error

        public ScholarshipEvaluationResult(bool isEligible, string label, string reason, int rank)
        {
            IsEligible = isEligible;
            Label = label;
            Reason = reason;
            Rank = rank;
        }
    }
}
