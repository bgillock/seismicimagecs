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
    public partial class Cube :  IEquatable<Cube>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Cube" /> class.
        /// </summary>
        /// <param name="CubeName">CubeName.</param>
        /// <param name="CubeId">CubeId.</param>
        /// <param name="Property">Property.</param>
        /// <param name="NInlines">NInlines.</param>
        /// <param name="NCrosslines">NCrosslines.</param>
        /// <param name="NSamples">NSamples.</param>
        /// <param name="SampleRate">SampleRate.</param>
        /// <param name="Domain">Domain.</param>
        /// <param name="LocationXY">LocationXY.</param>
        /// <param name="Annotation">Annotation.</param>
        /// <param name="Amplitude">Amplitude.</param>
        public Cube(string CubeName = null, string CubeId = null, string Property = null, double? NInlines = null, double? NCrosslines = null, double? NSamples = null, double? SampleRate = null, string Domain = null, CubeLocationXY LocationXY = null, CubeAnnotation Annotation = null, CubeAmplitude Amplitude = null)
        {
            this.CubeName = CubeName;
            this.CubeId = CubeId;
            this.Property = Property;
            this.NInlines = NInlines;
            this.NCrosslines = NCrosslines;
            this.NSamples = NSamples;
            this.SampleRate = SampleRate;
            this.Domain = Domain;
            this.LocationXY = LocationXY;
            this.Annotation = Annotation;
            this.Amplitude = Amplitude;
            
        }

        
        /// <summary>
        /// Gets or Sets CubeName
        /// </summary>
        public string CubeName { get; set; }

        
        /// <summary>
        /// Gets or Sets CubeId
        /// </summary>
        public string CubeId { get; set; }

        
        /// <summary>
        /// Gets or Sets Property
        /// </summary>
        public string Property { get; set; }

        
        /// <summary>
        /// Gets or Sets NInlines
        /// </summary>
        public double? NInlines { get; set; }

        
        /// <summary>
        /// Gets or Sets NCrosslines
        /// </summary>
        public double? NCrosslines { get; set; }

        
        /// <summary>
        /// Gets or Sets NSamples
        /// </summary>
        public double? NSamples { get; set; }

        
        /// <summary>
        /// Gets or Sets SampleRate
        /// </summary>
        public double? SampleRate { get; set; }

        
        /// <summary>
        /// Gets or Sets Domain
        /// </summary>
        public string Domain { get; set; }

        
        /// <summary>
        /// Gets or Sets LocationXY
        /// </summary>
        public CubeLocationXY LocationXY { get; set; }

        
        /// <summary>
        /// Gets or Sets Annotation
        /// </summary>
        public CubeAnnotation Annotation { get; set; }

        
        /// <summary>
        /// Gets or Sets Amplitude
        /// </summary>
        public CubeAmplitude Amplitude { get; set; }

        

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Cube {\n");
            sb.Append("  CubeName: ").Append(CubeName).Append("\n");
            sb.Append("  CubeId: ").Append(CubeId).Append("\n");
            sb.Append("  Property: ").Append(Property).Append("\n");
            sb.Append("  NInlines: ").Append(NInlines).Append("\n");
            sb.Append("  NCrosslines: ").Append(NCrosslines).Append("\n");
            sb.Append("  NSamples: ").Append(NSamples).Append("\n");
            sb.Append("  SampleRate: ").Append(SampleRate).Append("\n");
            sb.Append("  Domain: ").Append(Domain).Append("\n");
            sb.Append("  LocationXY: ").Append(LocationXY).Append("\n");
            sb.Append("  Annotation: ").Append(Annotation).Append("\n");
            sb.Append("  Amplitude: ").Append(Amplitude).Append("\n");
            
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
            return Equals((Cube)obj);
        }

        /// <summary>
        /// Returns true if Cube instances are equal
        /// </summary>
        /// <param name="other">Instance of Cube to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Cube other)
        {

            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return 
                (
                    this.CubeName == other.CubeName ||
                    this.CubeName != null &&
                    this.CubeName.Equals(other.CubeName)
                ) && 
                (
                    this.CubeId == other.CubeId ||
                    this.CubeId != null &&
                    this.CubeId.Equals(other.CubeId)
                ) && 
                (
                    this.Property == other.Property ||
                    this.Property != null &&
                    this.Property.Equals(other.Property)
                ) && 
                (
                    this.NInlines == other.NInlines ||
                    this.NInlines != null &&
                    this.NInlines.Equals(other.NInlines)
                ) && 
                (
                    this.NCrosslines == other.NCrosslines ||
                    this.NCrosslines != null &&
                    this.NCrosslines.Equals(other.NCrosslines)
                ) && 
                (
                    this.NSamples == other.NSamples ||
                    this.NSamples != null &&
                    this.NSamples.Equals(other.NSamples)
                ) && 
                (
                    this.SampleRate == other.SampleRate ||
                    this.SampleRate != null &&
                    this.SampleRate.Equals(other.SampleRate)
                ) && 
                (
                    this.Domain == other.Domain ||
                    this.Domain != null &&
                    this.Domain.Equals(other.Domain)
                ) && 
                (
                    this.LocationXY == other.LocationXY ||
                    this.LocationXY != null &&
                    this.LocationXY.Equals(other.LocationXY)
                ) && 
                (
                    this.Annotation == other.Annotation ||
                    this.Annotation != null &&
                    this.Annotation.Equals(other.Annotation)
                ) && 
                (
                    this.Amplitude == other.Amplitude ||
                    this.Amplitude != null &&
                    this.Amplitude.Equals(other.Amplitude)
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
                
                    if (this.CubeName != null)
                    hash = hash * 59 + this.CubeName.GetHashCode();
                
                    if (this.CubeId != null)
                    hash = hash * 59 + this.CubeId.GetHashCode();
                
                    if (this.Property != null)
                    hash = hash * 59 + this.Property.GetHashCode();
                
                    if (this.NInlines != null)
                    hash = hash * 59 + this.NInlines.GetHashCode();
                
                    if (this.NCrosslines != null)
                    hash = hash * 59 + this.NCrosslines.GetHashCode();
                
                    if (this.NSamples != null)
                    hash = hash * 59 + this.NSamples.GetHashCode();
                
                    if (this.SampleRate != null)
                    hash = hash * 59 + this.SampleRate.GetHashCode();
                
                    if (this.Domain != null)
                    hash = hash * 59 + this.Domain.GetHashCode();
                
                    if (this.LocationXY != null)
                    hash = hash * 59 + this.LocationXY.GetHashCode();
                
                    if (this.Annotation != null)
                    hash = hash * 59 + this.Annotation.GetHashCode();
                
                    if (this.Amplitude != null)
                    hash = hash * 59 + this.Amplitude.GetHashCode();
                
                return hash;
            }
        }

        #region Operators

        public static bool operator ==(Cube left, Cube right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Cube left, Cube right)
        {
            return !Equals(left, right);
        }

        #endregion Operators

    }
}
