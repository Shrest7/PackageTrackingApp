using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageTrackingApp.Core.Domains
{
    public enum PackageCategory { Small, Big, Medium }
    public class Package
    {
        private const float _maxWidth = 15;
        private const float _maxLength = 40;
        private const float _maxHeight = 25;
        private const float _maxWeight = 25;

        [Key]
        public Guid Guid { get; protected set; }
        public virtual Customer Customer { get; protected set; }
        public virtual Seller Seller { get; protected set; }
        public string Name { get; protected set; }
        public bool IsPaid { get; protected set; } = false;
        public bool IsDelivered { get; protected set; } = false;
        public PackageCategory Category { get; protected set; }

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

        public Package()
        {
            
        }

        public Package(Customer customer, Seller seller, string name,
            float weight, float height, float length, float width)
        {
            Guid = Guid.NewGuid();
            Customer = customer;
            Seller = seller;
            Name = name;
            SetWeight(weight);
            SetHeight(height);
            SetLength(length);
            SetWidth(width);
        }

        private void SetWidth(float width)
        {
            if (Width == width)
            {
                return;
            }
            if (width <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(width), "Width must be greater than 0!");
            }
            if (width > _maxWidth)
            {
                throw new ArgumentOutOfRangeException(nameof(width), $"Package's width can't exceed {_maxWidth}cm!");
            }

            Width = width;
        }

        private void SetLength(float length)
        {
            if (Length == length)
            {
                return;
            }
            if (length <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(length), "Length must be greater than 0!");
            }
            if (length > _maxLength)
            {
                throw new ArgumentOutOfRangeException(nameof(length), $"Package's length can't exceed {_maxLength}cm!");
            }

            Length = length;
        }

        private void SetHeight(float height)
        {
            if (Height == height)
            {
                return;
            }
            if (height <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(height), "Height must be greater than 0!");
            }
            if (height > _maxHeight)
            {
                throw new ArgumentOutOfRangeException(nameof(height), $"Package's height can't exceed {_maxHeight}cm!");
            }

            Height = height;
        }

        private void SetWeight(float weight)
        {
            if(Weight == weight)
            {
                return;
            }
            if(weight <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(weight), "Weight must be greater than 0!");
            }
            if(weight > _maxWeight)
            {
                throw new ArgumentOutOfRangeException(nameof(weight), $"Package's weight can't exceed {_maxWeight}kg!");
            }

            Weight = weight;
        }

        public void AssignPackageToCategory()
        {
            float volume = (float)(Length * Height * Width);

            if (volume <= 20000)
            {
                Category = PackageCategory.Small;
            }
            else if (volume > 20000 && volume <= 40000)
            {
                Category = PackageCategory.Medium;
            }
            else if (volume > 40000 && volume <= 80000)
            {
                Category = PackageCategory.Big;
            }
            else
            {
                throw new Exception($"Package is too big! Calculated volume: {volume} " +
                    $"can't exceed 80000 cubic centimeters.");
            }
        }
    }
}
