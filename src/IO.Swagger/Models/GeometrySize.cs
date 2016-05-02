using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace IO.Swagger.Models
{
    /// <summary>
    /// 
    /// </summary>
    public partial class GeometrySize :  IEquatable<GeometrySize>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GeometrySize" /> class.
        /// </summary>
        /// <param name="Width">Width.</param>
        /// <param name="Height">Height.</param>
        public GeometrySize(double? Width = null, double? Height = null)
        {
            this.Width = Width;
            this.Height = Height;
            
        }

        
        /// <summary>
        /// Gets or Sets Width
        /// </summary>
        public double? Width { get; set; }

        
        /// <summary>
        /// Gets or Sets Height
        /// </summary>
        public double? Height { get; set; }

        

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class GeometrySize {\n");
            sb.Append("  Width: ").Append(Width).Append("\n");
            sb.Append("  Height: ").Append(Height).Append("\n");
            
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="obj">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((GeometrySize)obj);
        }

        /// <summary>
        /// Returns true if GeometrySize instances are equal
        /// </summary>
        /// <param name="other">Instance of GeometrySize to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(GeometrySize other)
        {

            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return 
                (
                    this.Width == other.Width ||
                    this.Width != null &&
                    this.Width.Equals(other.Width)
                ) && 
                (
                    this.Height == other.Height ||
                    this.Height != null &&
                    this.Height.Equals(other.Height)
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            // credit: http://stackoverflow.com/a/263416/677735
            unchecked // Overflow is fine, just wrap
            {
                int hash = 41;
                // Suitable nullity checks etc, of course :)
                
                    if (this.Width != null)
                    hash = hash * 59 + this.Width.GetHashCode();
                
                    if (this.Height != null)
                    hash = hash * 59 + this.Height.GetHashCode();
                
                return hash;
            }
        }

        #region Operators

        public static bool operator ==(GeometrySize left, GeometrySize right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(GeometrySize left, GeometrySize right)
        {
            return !Equals(left, right);
        }

        #endregion Operators

    }
}
