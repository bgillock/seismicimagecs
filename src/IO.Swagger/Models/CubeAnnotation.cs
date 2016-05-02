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
    public partial class CubeAnnotation :  IEquatable<CubeAnnotation>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CubeAnnotation" /> class.
        /// </summary>
        /// <param name="MinCrossline">MinCrossline.</param>
        /// <param name="MinInline">MinInline.</param>
        /// <param name="IncInline">IncInline.</param>
        /// <param name="IncCrossline">IncCrossline.</param>
        /// <param name="MaxInline">MaxInline.</param>
        /// <param name="MaxCrossline">MaxCrossline.</param>
        public CubeAnnotation(double? MinCrossline = null, double? MinInline = null, double? IncInline = null, double? IncCrossline = null, double? MaxInline = null, double? MaxCrossline = null)
        {
            this.MinCrossline = MinCrossline;
            this.MinInline = MinInline;
            this.IncInline = IncInline;
            this.IncCrossline = IncCrossline;
            this.MaxInline = MaxInline;
            this.MaxCrossline = MaxCrossline;
            
        }

        
        /// <summary>
        /// Gets or Sets MinCrossline
        /// </summary>
        public double? MinCrossline { get; set; }

        
        /// <summary>
        /// Gets or Sets MinInline
        /// </summary>
        public double? MinInline { get; set; }

        
        /// <summary>
        /// Gets or Sets IncInline
        /// </summary>
        public double? IncInline { get; set; }

        
        /// <summary>
        /// Gets or Sets IncCrossline
        /// </summary>
        public double? IncCrossline { get; set; }

        
        /// <summary>
        /// Gets or Sets MaxInline
        /// </summary>
        public double? MaxInline { get; set; }

        
        /// <summary>
        /// Gets or Sets MaxCrossline
        /// </summary>
        public double? MaxCrossline { get; set; }

        

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class CubeAnnotation {\n");
            sb.Append("  MinCrossline: ").Append(MinCrossline).Append("\n");
            sb.Append("  MinInline: ").Append(MinInline).Append("\n");
            sb.Append("  IncInline: ").Append(IncInline).Append("\n");
            sb.Append("  IncCrossline: ").Append(IncCrossline).Append("\n");
            sb.Append("  MaxInline: ").Append(MaxInline).Append("\n");
            sb.Append("  MaxCrossline: ").Append(MaxCrossline).Append("\n");
            
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
            return Equals((CubeAnnotation)obj);
        }

        /// <summary>
        /// Returns true if CubeAnnotation instances are equal
        /// </summary>
        /// <param name="other">Instance of CubeAnnotation to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(CubeAnnotation other)
        {

            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return 
                (
                    this.MinCrossline == other.MinCrossline ||
                    this.MinCrossline != null &&
                    this.MinCrossline.Equals(other.MinCrossline)
                ) && 
                (
                    this.MinInline == other.MinInline ||
                    this.MinInline != null &&
                    this.MinInline.Equals(other.MinInline)
                ) && 
                (
                    this.IncInline == other.IncInline ||
                    this.IncInline != null &&
                    this.IncInline.Equals(other.IncInline)
                ) && 
                (
                    this.IncCrossline == other.IncCrossline ||
                    this.IncCrossline != null &&
                    this.IncCrossline.Equals(other.IncCrossline)
                ) && 
                (
                    this.MaxInline == other.MaxInline ||
                    this.MaxInline != null &&
                    this.MaxInline.Equals(other.MaxInline)
                ) && 
                (
                    this.MaxCrossline == other.MaxCrossline ||
                    this.MaxCrossline != null &&
                    this.MaxCrossline.Equals(other.MaxCrossline)
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
                
                    if (this.MinCrossline != null)
                    hash = hash * 59 + this.MinCrossline.GetHashCode();
                
                    if (this.MinInline != null)
                    hash = hash * 59 + this.MinInline.GetHashCode();
                
                    if (this.IncInline != null)
                    hash = hash * 59 + this.IncInline.GetHashCode();
                
                    if (this.IncCrossline != null)
                    hash = hash * 59 + this.IncCrossline.GetHashCode();
                
                    if (this.MaxInline != null)
                    hash = hash * 59 + this.MaxInline.GetHashCode();
                
                    if (this.MaxCrossline != null)
                    hash = hash * 59 + this.MaxCrossline.GetHashCode();
                
                return hash;
            }
        }

        #region Operators

        public static bool operator ==(CubeAnnotation left, CubeAnnotation right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(CubeAnnotation left, CubeAnnotation right)
        {
            return !Equals(left, right);
        }

        #endregion Operators

    }
}
