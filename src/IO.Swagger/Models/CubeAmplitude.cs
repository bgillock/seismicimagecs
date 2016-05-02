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
    public partial class CubeAmplitude :  IEquatable<CubeAmplitude>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CubeAmplitude" /> class.
        /// </summary>
        /// <param name="Min">Min.</param>
        /// <param name="Max">Max.</param>
        public CubeAmplitude(double? Min = null, double? Max = null)
        {
            this.Min = Min;
            this.Max = Max;
            
        }

        
        /// <summary>
        /// Gets or Sets Min
        /// </summary>
        public double? Min { get; set; }

        
        /// <summary>
        /// Gets or Sets Max
        /// </summary>
        public double? Max { get; set; }

        

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class CubeAmplitude {\n");
            sb.Append("  Min: ").Append(Min).Append("\n");
            sb.Append("  Max: ").Append(Max).Append("\n");
            
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
            return Equals((CubeAmplitude)obj);
        }

        /// <summary>
        /// Returns true if CubeAmplitude instances are equal
        /// </summary>
        /// <param name="other">Instance of CubeAmplitude to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(CubeAmplitude other)
        {

            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return 
                (
                    this.Min == other.Min ||
                    this.Min != null &&
                    this.Min.Equals(other.Min)
                ) && 
                (
                    this.Max == other.Max ||
                    this.Max != null &&
                    this.Max.Equals(other.Max)
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
                
                    if (this.Min != null)
                    hash = hash * 59 + this.Min.GetHashCode();
                
                    if (this.Max != null)
                    hash = hash * 59 + this.Max.GetHashCode();
                
                return hash;
            }
        }

        #region Operators

        public static bool operator ==(CubeAmplitude left, CubeAmplitude right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(CubeAmplitude left, CubeAmplitude right)
        {
            return !Equals(left, right);
        }

        #endregion Operators

    }
}
