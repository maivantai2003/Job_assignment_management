using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Job_assignment_management.Shared.Common.Helpers
{
    public static class ErrorMessages
    {
        public const string CreateFailed = "Failed to add the new item.";
        public const string UpdateFailed = "Failed to update the item.";
        public const string DeleteFailed = "Failed to delete the item.";
        public const string FindFailed = "Failed to find the requested item.";
        public const string InvalidDate = "The provided date is invalid or in an incorrect format.";
        public const string UpdateDateFailed = "Failed to update the date. Please check the date format and try again.";
        public static string CreateFailedMessage(string itemName)
        {
            return $"Failed to add the item '{itemName}'.";
        }

        public static string UpdateFailedMessage(string itemName)
        {
            return $"Failed to update the item '{itemName}'.";
        }

        public static string DeleteFailedMessage(string itemName)
        {
            return $"Failed to delete the item '{itemName}'.";
        }

        public static string SearchFailedMessage(string searchCriteria)
        {
            return $"Failed to find the item with the criteria '{searchCriteria}'.";
        }

        public static string InvalidDateMessage(string fieldName)
        {
            return $"The date provided for '{fieldName}' is invalid or in an incorrect format.";
        }

        public static string UpdateDateFailedMessage(string fieldName)
        {
            return $"Failed to update the date for '{fieldName}'. Please check the date format and try again.";
        }

        public static string NotFoundMessage(string itemName)
        {
            return $"The requested item '{itemName}' was not found.";
        }
    }
}
