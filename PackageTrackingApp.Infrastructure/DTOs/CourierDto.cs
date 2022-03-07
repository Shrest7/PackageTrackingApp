using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageTrackingApp.Infrastructure.DTOs
{
    public class CourierDto
    {
        private float? _experience;
        public Guid Guid { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public float? Experience 
        { 
            get { return _experience; }
            set 
            {
                if (value is null)
                {
                    _experience = null;
                }
                else
                {
                    _experience = (float?) Math.Round(value.Value, 2);
                }
            }
        }
    }
}
