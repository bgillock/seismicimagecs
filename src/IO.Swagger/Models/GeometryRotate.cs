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
    public partial class GeometryRotate :  IEquatable<GeometryRotate>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GeometryRotate" /> class.
        /// </summary>
        /// <param name="X">X.</param>
        /// <param name="Y">Y.</param>
        /// <param name="Z">Z.</param>
        public GeometryRotate(double? X = null, double? Y = null, double? Z = null)
        {
            this.X = X;
            this.Y = Y;
            this.Z = Z;
            
        }

        
        /// <summary>
        /// Gets or Sets X
        /// </summary>
        public double? X { get; set; }

        
        /// <summary>
        /// Gets or Sets Y
        /// </summary>
        public double? Y { get; set; }

        
        /// <summary>
        /// Gets or Sets Z
        /// </summary>
        public double? Z { get; set; }

        

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class GeometryRotate {\n");
            sb.Append("  X: ").Append(X).Append("\n");
            sb.Append("  Y: ").Append(Y).Append("\n");
            sb.Append("  Z: ").Append(Z).Append("\n");
            
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
            return Equals((GeometryRotate)obj);
        }

        /// <summary>
        /// Returns true if GeometryRotate instances are equal
        /// </summary>
        /// <param name="other">Instance of GeometryRotate to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(GeometryRotate other)
        {

            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return 
                (
                    this.X == other.X ||
                    this.X != null &&
                    this.X.Equals(other.X)
                ) && 
                (
                    this.Y == other.Y ||
                    this.Y != null &&
                    this.Y.Equals(other.Y)
                ) && 
                (
                    this.Z == other.Z ||
                    this.Z != null &&
                    this.Z.Equals(other.Z)
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
                
                    if (this.X != null)
                    hash = hash * 59 + this.X.GetHashCode();
                
                    if (this.Y != null)
                    hash = hash * 59 + this.Y.GetHashCode();
                
                    if (this.Z != null)
                    hash = hash * 59 + this.Z.GetHashCode();
                
                return hash;
            }
        }

        #region Operators

        public static bool operator ==(GeometryRotate left, GeometryRotate right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(GeometryRotate left, GeometryRotate right)
        {
            return !Equals(left, right);
        }

        #endregion Operators

    }
}
