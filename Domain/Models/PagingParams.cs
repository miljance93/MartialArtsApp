using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    
    public class PagingParams
    { 
        const int maxPageSize = 50;
        [Required]
        public int PageNumber { get; set; } = 1;
        private int _pageSize = 2;
        [Required]
        public int PageSize
        {
            get { return _pageSize; }
            set
            {
                _pageSize = (value > maxPageSize) ? maxPageSize : value;
            }
        }
    }
}
