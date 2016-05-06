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
    public partial class Geometry :  IEquatable<Geometry>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Geometry" /> class.
        /// </summary>
        /// <param name="Width">Width.</param>
        /// <param name="Height">Height.</param>
        /// <param name="Translate">Translate.</param>
        /// <param name="Rotation">Rotation.</param>
        public Geometry(double? Width = null, double? Height = null, GeometryTranslate Translate = null, GeometryRotate Rotation = null)
        {
            this.Width = Width;
            this.Height = Height;
            this.Translate = Translate;
            this.Rotation = Rotation;
            
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
        /// Gets or Sets Translate
        /// </summary>
        public GeometryTranslate Translate { get; set; }

        
        /// <summary>
        /// Gets or Sets Rotation
        /// </summary>
        public GeometryRotate Rotation { get; set; }

        

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Geometry {\n");
            sb.Append("  Width: ").Append(Width).Append("\n");
            sb.Append("  Height: ").Append(Height).Append("\n");
            sb.Append("  Translate: ").Append(Translate).Append("\n");
            sb.Append("  Rotation: ").Append(Rotation).Append("\n");
            
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
            return Equals((Geometry)obj);
        }

        /// <summary>
        /// Returns true if Geometry instances are equal
        /// </summary>
        /// <param name="other">Instance of Geometry to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Geometry other)
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
                ) && 
                (
                    this.Translate == other.Translate ||
                    this.Translate != null &&
                    this.Translate.Equals(other.Translate)
                ) && 
                (
                    this.Rotation == other.Rotation ||
                    this.Rotation != null &&
                    this.Rotation.Equals(other.Rotation)
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
                
                    if (this.Translate != null)
                    hash = hash * 59 + this.Translate.GetHashCode();
                
                    if (this.Rotation != null)
                    hash = hash * 59 + this.Rotation.GetHashCode();
                
                return hash;
            }
        }

        #region Operators

        public static bool operator ==(Geometry left, Geometry right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Geometry left, Geometry right)
        {
            return !Equals(left, right);
        }

        #endregion Operators

    }
}
