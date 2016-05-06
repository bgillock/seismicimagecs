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
    public partial class PlaneImages :  IEquatable<PlaneImages>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PlaneImages" /> class.
        /// </summary>
        /// <param name="LowResolution">LowResolution.</param>
        /// <param name="HighResolution">HighResolution.</param>
        /// <param name="MedResolution">MedResolution.</param>
        /// <param name="ActualResolution">ActualResolution.</param>
        public PlaneImages(Image LowResolution = null, Image HighResolution = null, Image MedResolution = null, Image ActualResolution = null)
        {
            this.LowResolution = LowResolution;
            this.HighResolution = HighResolution;
            this.MedResolution = MedResolution;
            this.ActualResolution = ActualResolution;
            
        }

        
        /// <summary>
        /// Gets or Sets LowResolution
        /// </summary>
        public Image LowResolution { get; set; }

        
        /// <summary>
        /// Gets or Sets HighResolution
        /// </summary>
        public Image HighResolution { get; set; }

        
        /// <summary>
        /// Gets or Sets MedResolution
        /// </summary>
        public Image MedResolution { get; set; }

        
        /// <summary>
        /// Gets or Sets ActualResolution
        /// </summary>
        public Image ActualResolution { get; set; }

        

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class PlaneImages {\n");
            sb.Append("  LowResolution: ").Append(LowResolution).Append("\n");
            sb.Append("  HighResolution: ").Append(HighResolution).Append("\n");
            sb.Append("  MedResolution: ").Append(MedResolution).Append("\n");
            sb.Append("  ActualResolution: ").Append(ActualResolution).Append("\n");
            
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
            return Equals((PlaneImages)obj);
        }

        /// <summary>
        /// Returns true if PlaneImages instances are equal
        /// </summary>
        /// <param name="other">Instance of PlaneImages to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(PlaneImages other)
        {

            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return 
                (
                    this.LowResolution == other.LowResolution ||
                    this.LowResolution != null &&
                    this.LowResolution.Equals(other.LowResolution)
                ) && 
                (
                    this.HighResolution == other.HighResolution ||
                    this.HighResolution != null &&
                    this.HighResolution.Equals(other.HighResolution)
                ) && 
                (
                    this.MedResolution == other.MedResolution ||
                    this.MedResolution != null &&
                    this.MedResolution.Equals(other.MedResolution)
                ) && 
                (
                    this.ActualResolution == other.ActualResolution ||
                    this.ActualResolution != null &&
                    this.ActualResolution.Equals(other.ActualResolution)
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
                
                    if (this.LowResolution != null)
                    hash = hash * 59 + this.LowResolution.GetHashCode();
                
                    if (this.HighResolution != null)
                    hash = hash * 59 + this.HighResolution.GetHashCode();
                
                    if (this.MedResolution != null)
                    hash = hash * 59 + this.MedResolution.GetHashCode();
                
                    if (this.ActualResolution != null)
                    hash = hash * 59 + this.ActualResolution.GetHashCode();
                
                return hash;
            }
        }

        #region Operators

        public static bool operator ==(PlaneImages left, PlaneImages right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(PlaneImages left, PlaneImages right)
        {
            return !Equals(left, right);
        }

        #endregion Operators

    }
}
