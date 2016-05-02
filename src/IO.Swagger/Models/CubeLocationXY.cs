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
    public partial class CubeLocationXY :  IEquatable<CubeLocationXY>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CubeLocationXY" /> class.
        /// </summary>
        /// <param name="CRS">The code for the CRS.</param>
        /// <param name="OriginX">OriginX.</param>
        /// <param name="OriginY">OriginY.</param>
        /// <param name="EndFirstInlineX">EndFirstInlineX.</param>
        /// <param name="EndFirstCrosslineX">EndFirstCrosslineX.</param>
        /// <param name="EndFirstInlineY">EndFirstInlineY.</param>
        /// <param name="EndFirstCrosslineY">EndFirstCrosslineY.</param>
        public CubeLocationXY(string CRS = null, double? OriginX = null, double? OriginY = null, double? EndFirstInlineX = null, double? EndFirstCrosslineX = null, double? EndFirstInlineY = null, double? EndFirstCrosslineY = null)
        {
            this.CRS = CRS;
            this.OriginX = OriginX;
            this.OriginY = OriginY;
            this.EndFirstInlineX = EndFirstInlineX;
            this.EndFirstCrosslineX = EndFirstCrosslineX;
            this.EndFirstInlineY = EndFirstInlineY;
            this.EndFirstCrosslineY = EndFirstCrosslineY;
            
        }

        
        /// <summary>
        /// The code for the CRS
        /// </summary>
        /// <value>The code for the CRS</value>
        public string CRS { get; set; }

        
        /// <summary>
        /// Gets or Sets OriginX
        /// </summary>
        public double? OriginX { get; set; }

        
        /// <summary>
        /// Gets or Sets OriginY
        /// </summary>
        public double? OriginY { get; set; }

        
        /// <summary>
        /// Gets or Sets EndFirstInlineX
        /// </summary>
        public double? EndFirstInlineX { get; set; }

        
        /// <summary>
        /// Gets or Sets EndFirstCrosslineX
        /// </summary>
        public double? EndFirstCrosslineX { get; set; }

        
        /// <summary>
        /// Gets or Sets EndFirstInlineY
        /// </summary>
        public double? EndFirstInlineY { get; set; }

        
        /// <summary>
        /// Gets or Sets EndFirstCrosslineY
        /// </summary>
        public double? EndFirstCrosslineY { get; set; }

        

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class CubeLocationXY {\n");
            sb.Append("  CRS: ").Append(CRS).Append("\n");
            sb.Append("  OriginX: ").Append(OriginX).Append("\n");
            sb.Append("  OriginY: ").Append(OriginY).Append("\n");
            sb.Append("  EndFirstInlineX: ").Append(EndFirstInlineX).Append("\n");
            sb.Append("  EndFirstCrosslineX: ").Append(EndFirstCrosslineX).Append("\n");
            sb.Append("  EndFirstInlineY: ").Append(EndFirstInlineY).Append("\n");
            sb.Append("  EndFirstCrosslineY: ").Append(EndFirstCrosslineY).Append("\n");
            
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
            return Equals((CubeLocationXY)obj);
        }

        /// <summary>
        /// Returns true if CubeLocationXY instances are equal
        /// </summary>
        /// <param name="other">Instance of CubeLocationXY to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(CubeLocationXY other)
        {

            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return 
                (
                    this.CRS == other.CRS ||
                    this.CRS != null &&
                    this.CRS.Equals(other.CRS)
                ) && 
                (
                    this.OriginX == other.OriginX ||
                    this.OriginX != null &&
                    this.OriginX.Equals(other.OriginX)
                ) && 
                (
                    this.OriginY == other.OriginY ||
                    this.OriginY != null &&
                    this.OriginY.Equals(other.OriginY)
                ) && 
                (
                    this.EndFirstInlineX == other.EndFirstInlineX ||
                    this.EndFirstInlineX != null &&
                    this.EndFirstInlineX.Equals(other.EndFirstInlineX)
                ) && 
                (
                    this.EndFirstCrosslineX == other.EndFirstCrosslineX ||
                    this.EndFirstCrosslineX != null &&
                    this.EndFirstCrosslineX.Equals(other.EndFirstCrosslineX)
                ) && 
                (
                    this.EndFirstInlineY == other.EndFirstInlineY ||
                    this.EndFirstInlineY != null &&
                    this.EndFirstInlineY.Equals(other.EndFirstInlineY)
                ) && 
                (
                    this.EndFirstCrosslineY == other.EndFirstCrosslineY ||
                    this.EndFirstCrosslineY != null &&
                    this.EndFirstCrosslineY.Equals(other.EndFirstCrosslineY)
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
                
                    if (this.CRS != null)
                    hash = hash * 59 + this.CRS.GetHashCode();
                
                    if (this.OriginX != null)
                    hash = hash * 59 + this.OriginX.GetHashCode();
                
                    if (this.OriginY != null)
                    hash = hash * 59 + this.OriginY.GetHashCode();
                
                    if (this.EndFirstInlineX != null)
                    hash = hash * 59 + this.EndFirstInlineX.GetHashCode();
                
                    if (this.EndFirstCrosslineX != null)
                    hash = hash * 59 + this.EndFirstCrosslineX.GetHashCode();
                
                    if (this.EndFirstInlineY != null)
                    hash = hash * 59 + this.EndFirstInlineY.GetHashCode();
                
                    if (this.EndFirstCrosslineY != null)
                    hash = hash * 59 + this.EndFirstCrosslineY.GetHashCode();
                
                return hash;
            }
        }

        #region Operators

        public static bool operator ==(CubeLocationXY left, CubeLocationXY right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(CubeLocationXY left, CubeLocationXY right)
        {
            return !Equals(left, right);
        }

        #endregion Operators

    }
}
