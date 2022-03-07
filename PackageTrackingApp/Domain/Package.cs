using PackageTrackingApp.Core.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageTrackingApp.Core.Domains
{
    public enum PackageCategory { Small, Big, Medium }
    public class Package
    {
        private const float _maxDimensionLength = 150;
        private const float _maxSumOfDimensions = 300;
        private const float _maxWeight = 25;

        [Key]
        public Guid Guid { get; protected set; }
        [Required]
        public Guid CustomerGuid { get; protected set; }
        [Required]
        public Guid SellerGuid { get; protected set; }
        [Required]
        public Guid CourierGuid { get; protected set; }
        public string Name { get; set; }
        public bool IsPaid { get; protected set; } = false;
        public bool IsDelivered { get; protected set; } = false;
        //public Address Destination { get; protected set; }
        public DateTime? SentAt { get; protected set; }
        public DateTime? DeliveredAt { get; protected set; } = null;
        public PackageCategory Category { get; protected set; }
        public User Seller { get; set; }
        public User Customer { get; set; }
        public Courier Courier { get; set; }

        /// <summary>
        /// Weight of the package represented in kilograms.
        /// </summary>
        public float Weight { get; protected set; }

        /// <summary>
        /// Height of the package represented in centimeters.
        /// </summary>
        public float Height { get; protected set; }

        /// <summary>
        /// Length of the package represented in centimeters.
        /// </summary>
        public float Length { get; protected set; }

        /// <summary>
        /// Width of the package represented in centimeters.
        /// </summary>
        public float Width { get; protected set; }

        protected Package()
        {
            
        }

        public Package(Guid customerGuid, Guid sellerGuid, Guid courierGuid,
            string name, float weight, float height, float length, float width)
        {
            SentAt = DateTime.UtcNow;
            Name = name;
            CourierGuid = courierGuid;
            SetTransactionParties(customerGuid, sellerGuid);
            SetWeight(weight);
            SetHeight(height);
            SetLength(length);
            SetWidth(width);
            VerifySumOfDimensions();
            AssignPackageToCategory();
        }

        private void VerifySumOfDimensions()
        {
            float sum = Width + Length + Height;

            if(sum > _maxSumOfDimensions)
            {
                throw new Exception("Sum of dimensions can not exceed 300cm.");
            }
        }

        private void SetTransactionParties(Guid customerGuid, Guid sellerGuid)
        {
            if (customerGuid.Equals(Guid.Empty))
            {
                throw new Exception("Customer id can not be empty.");
            }

            if (sellerGuid.Equals(Guid.Empty))
            {
                throw new Exception("Seller id can not be empty.");
            }

            if (string.Equals(customerGuid, sellerGuid))
            {
                throw new Exception("Customer id can not be the same as seller id.");
            }

            SellerGuid = sellerGuid;
            CustomerGuid = customerGuid;
        }

        private void SetWidth(float width)
        {
            if (width <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(width), "Width must be greater than 0!");
            }
            if (Width == width)
            {
                return;
            }
            if (width > _maxDimensionLength)
            {
                throw new ArgumentOutOfRangeException(nameof(width), $"Package's width can't exceed {_maxDimensionLength}cm!");
            }

            Width = width;
        }

        private void SetLength(float length)
        {
            if (length <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(length), "Length must be greater than 0!");
            }
            if (Length == length)
            {
                return;
            }
            if (length > _maxDimensionLength)
            {
                throw new ArgumentOutOfRangeException(nameof(length), $"Package's length can't exceed {_maxDimensionLength}cm!");
            }

            Length = length;
        }

        private void SetHeight(float height)
        {
            if (height <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(height), "Height must be greater than 0!");
            }
            if (Height == height)
            {
                return;
            }
            if (height > _maxDimensionLength)
            {
                throw new ArgumentOutOfRangeException(nameof(height), $"Package's height can't exceed {_maxDimensionLength}cm!");
            }

            Height = height;
        }

        private void SetWeight(float weight)
        {
            if (weight <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(weight), "Weight must be greater than 0!");
            }
            if (Weight == weight)
            {
                return;
            }
            if(weight > _maxWeight)
            {
                throw new ArgumentOutOfRangeException(nameof(weight), $"Package's weight can't exceed {_maxWeight}kg!");
            }

            Weight = weight;
        }

        public void MarkAsDelivered()
        {
            if (!IsPaid)
            {
                throw new Exception($"Can't mark package {Guid} as delivered - it's unpaid.");
            }

            IsDelivered = true;
            DeliveredAt = DateTime.UtcNow;
        }

        public void AssignPackageToCategory()
        {
            float volume = (float)(Length * Height * Width);

            if (volume <= 200000)
            {
                Category = PackageCategory.Small;
            }
            else if (volume > 200000 && volume <= 500000)
            {
                Category = PackageCategory.Medium;
            }
            else if (volume > 500000)
            {
                Category = PackageCategory.Big;
            }
        }
    }
}
