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
    public partial class Plane :  IEquatable<Plane>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Plane" /> class.
        /// </summary>
        /// <param name="CubeId">CubeId.</param>
        /// <param name="PlaneType">PlaneType.</param>
        /// <param name="PlaneNumber">PlaneNumber.</param>
        /// <param name="PlaneGeometry">PlaneGeometry.</param>
        /// <param name="Images">Images.</param>
        public Plane(string CubeId = null, string PlaneType = null, double? PlaneNumber = null, Geometry PlaneGeometry = null, PlaneImages Images = null)
        {
            this.CubeId = CubeId;
            this.PlaneType = PlaneType;
            this.PlaneNumber = PlaneNumber;
            this.PlaneGeometry = PlaneGeometry;
            this.Images = Images;
            
        }

        
        /// <summary>
        /// Gets or Sets CubeId
        /// </summary>
        public string CubeId { get; set; }

        
        /// <summary>
        /// Gets or Sets PlaneType
        /// </summary>
        public string PlaneType { get; set; }

        
        /// <summary>
        /// Gets or Sets PlaneNumber
        /// </summary>
        public double? PlaneNumber { get; set; }

        
        /// <summary>
        /// Gets or Sets PlaneGeometry
        /// </summary>
        public Geometry PlaneGeometry { get; set; }

        
        /// <summary>
        /// Gets or Sets Images
        /// </summary>
        public PlaneImages Images { get; set; }

        

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Plane {\n");
            sb.Append("  CubeId: ").Append(CubeId).Append("\n");
            sb.Append("  PlaneType: ").Append(PlaneType).Append("\n");
            sb.Append("  PlaneNumber: ").Append(PlaneNumber).Append("\n");
            sb.Append("  PlaneGeometry: ").Append(PlaneGeometry).Append("\n");
            sb.Append("  Images: ").Append(Images).Append("\n");
            
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
            return Equals((Plane)obj);
        }

        /// <summary>
        /// Returns true if Plane instances are equal
        /// </summary>
        /// <param name="other">Instance of Plane to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Plane other)
        {

            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return 
                (
                    this.CubeId == other.CubeId ||
                    this.CubeId != null &&
                    this.CubeId.Equals(other.CubeId)
                ) && 
                (
                    this.PlaneType == other.PlaneType ||
                    this.PlaneType != null &&
                    this.PlaneType.Equals(other.PlaneType)
                ) && 
                (
                    this.PlaneNumber == other.PlaneNumber ||
                    this.PlaneNumber != null &&
                    this.PlaneNumber.Equals(other.PlaneNumber)
                ) && 
                (
                    this.PlaneGeometry == other.PlaneGeometry ||
                    this.PlaneGeometry != null &&
                    this.PlaneGeometry.Equals(other.PlaneGeometry)
                ) && 
                (
                    this.Images == other.Images ||
                    this.Images != null &&
                    this.Images.Equals(other.Images)
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
                
                    if (this.CubeId != null)
                    hash = hash * 59 + this.CubeId.GetHashCode();
                
                    if (this.PlaneType != null)
                    hash = hash * 59 + this.PlaneType.GetHashCode();
                
                    if (this.PlaneNumber != null)
                    hash = hash * 59 + this.PlaneNumber.GetHashCode();
                
                    if (this.PlaneGeometry != null)
                    hash = hash * 59 + this.PlaneGeometry.GetHashCode();
                
                    if (this.Images != null)
                    hash = hash * 59 + this.Images.GetHashCode();
                
                return hash;
            }
        }

        #region Operators

        public static bool operator ==(Plane left, Plane right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Plane left, Plane right)
        {
            return !Equals(left, right);
        }

        #endregion Operators

    }
}
