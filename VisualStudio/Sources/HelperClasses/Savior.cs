using System;
// =====================================================================
//
// Savior - Simplify Saving and Restoring Application Settings
//
// by Jim Hollenhorst, jim@ultrapico.com
// Copyright Ultrapico, March 2003
// http://www.ultrapico.com
//
// =====================================================================
using System.Globalization;
using System.Reflection;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Drawing;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Elreg.HelperClasses
{
	public class Savior
	{		
		public static string ToString(object settings)
		{
			string msg="";
			foreach(FieldInfo fi in settings.GetType().GetFields(
				BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public))
			{ 
				string theValue="";
				if(fi.GetValue(settings)!=null)theValue=fi.GetValue(settings).ToString();
				msg+="Name: "+fi.Name+" = "+theValue+
					"\n    FieldType: "+fi.FieldType+"\n\n";
			}
			return msg;
		}		
				
		public static void Save(object settings, RegistryKey key)
		{
		    // Iterate through each Field of the specified class using "Reflection".
			// The name of each Field is used to generate the name of the registry
			// value, sometimes with appended characters to specify elements of more
			// complex Field types such as a Font or a Point. Arrays are stored by
			// creating a new subkey with the same name as the Field. The subkey holds
			// values with names that are just the integers 0,1,2,... giving the index
			// of each value.
			//

			foreach(FieldInfo fi in settings.GetType().GetFields(
				BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public))
			{ 
				// If this field is an Enum it needs to be handled separately. The text
				// name for the enum is written to the registry.
				if(fi.FieldType.IsEnum)
				{
					key.SetValue(fi.Name,Enum.GetName(fi.FieldType,fi.GetValue(settings)));
				}

				// Otherwise each different field type is handled case by case using
				// a large switch statement
				else
				{
				    // Test the name of the Field type, converted to lower case
				    RegistryKey subkey;
				    switch (fi.FieldType.Name.ToLower())
					{
						case "string":
							key.SetValue(fi.Name,fi.GetValue(settings));
							break;

						case "boolean":
							key.SetValue(fi.Name,(bool)fi.GetValue(settings));
							break;

						case "int32":
							key.SetValue(fi.Name,(int)fi.GetValue(settings));
							break;

						case "decimal":
							decimal theDecimal=(decimal)fi.GetValue(settings);
							key.SetValue(fi.Name,(int)theDecimal);
							break;

						case "single":
							key.SetValue(fi.Name,(float)fi.GetValue(settings));
							break;

						case "double":
							key.SetValue(fi.Name,(double)fi.GetValue(settings));
							break;

						// Store a Point as two separate integers
						case "point": 
							Point point=(Point)fi.GetValue(settings);
							key.SetValue(fi.Name+".X",point.X);
							key.SetValue(fi.Name+".Y",point.Y);
							break;

						// Store a Size as two separate integers
						case "size":
							Size size=(Size)fi.GetValue(settings);
							key.SetValue(fi.Name+".Height",size.Height);
							key.SetValue(fi.Name+".Width",size.Width);
							break;

						// byte arrays are a native registry type and thus easy to handle
						case "byte[]":
							byte[] bytes = (byte[])fi.GetValue(settings);
							if(bytes==null)break;
							key.SetValue(fi.Name,bytes);
							break;

						// string arrays are a native registry type and thus easy to handle
						case "string[]":
							string[] strings = (string[])fi.GetValue(settings);
							if(strings==null)break;
							key.SetValue(fi.Name,strings);
							break;

						// For arrays that aren't native registry types, create a subkey and then
						// create values that are numbered sequentially. First delete the subkey
						// if it already exists then refill it with all the values of the array.
						case "int32[]":
							int[] numbers = (int[])fi.GetValue(settings);
							if(numbers==null)break;
							key.DeleteSubKey(fi.Name,false);   // first delete all the old values
							subkey=key.CreateSubKey(fi.Name);
							for(int i=0;i<numbers.Length;i++)
							{
							    if (subkey != null) subkey.SetValue(i.ToString(),numbers[i]);
							}
							break;
						
						case "boolean[]":
							bool[] bools = (bool[])fi.GetValue(settings);
							if(bools==null)break;
							key.DeleteSubKey(fi.Name,false);   // first delete all the old values
							subkey=key.CreateSubKey(fi.Name);
							for(int i=0;i<bools.Length;i++)
							{
							    if (subkey != null) subkey.SetValue(i.ToString(),bools[i]);
							}
							break;

						case "single[]":
							float[] floats = (float[])fi.GetValue(settings);
							if(floats==null)break;
							key.DeleteSubKey(fi.Name,false);   // first delete all the old values
							subkey=key.CreateSubKey(fi.Name);
							for(int i=0;i<floats.Length;i++)
							{
							    if (subkey != null) subkey.SetValue(i.ToString(),floats[i]);
							}
							break;

						case "double[]":
							double[] doubles = (double[])fi.GetValue(settings);
							if(doubles==null)break;
							key.DeleteSubKey(fi.Name,false);   // first delete all the old values
							subkey=key.CreateSubKey(fi.Name);
							for(int i=0;i<doubles.Length;i++)
							{
							    if (subkey != null) subkey.SetValue(i.ToString(),doubles[i]);
							}
							break;

						// Saving colors is easy, unlike reading them, which is trickier. We just use the Color's
						// Name property. If there is no known name, the Argb value will be written in hexadecimal.
						case "color":
							key.SetValue(fi.Name,((Color)fi.GetValue(settings)).Name);
							break;

						// Save a TimeSpan using it's ToString() method
						case "timespan":
							key.SetValue(fi.Name,((TimeSpan)fi.GetValue(settings)).ToString());
							break;

						// Save a DateTime using it's ToString() method
						case "datetime":
							key.SetValue(fi.Name,((DateTime)fi.GetValue(settings)).ToString());
							break;

						// Save a Font by separately storing Name, Size, and Style
						case "font":
							key.SetValue(fi.Name+".Name",((Font)fi.GetValue(settings)).Name);
							key.SetValue(fi.Name+".Size",((Font)fi.GetValue(settings)).Size);
							key.SetValue(fi.Name+".Style",((Font)fi.GetValue(settings)).Style);
							break;

						default:
							MessageBox.Show("This Field type cannot be saved by the Savior class: "+fi.FieldType);
							break;
					}
				}
			}
		}

		public static void Save(object settings, string key)
		{
		    using (RegistryKey registryKey = Registry.CurrentUser.CreateSubKey(key))
		    {
                Save(settings, registryKey);
		    }
		}

	    public static void Save(object settings)
		{
			RegistryKey key=Application.UserAppDataRegistry;
			Save(settings,key);
		}

		public static void Read(object settings, RegistryKey key)
		{
			// Iterate through each Field of the specified class using "Reflection".
			// The name of each Field is used to generate the name of the registry
			// value, sometimes with appended characters to specify elements of more
			// complex Field types such as a Font or a Point. Arrays are read from
			// a subkey with the same name as the Field. The subkey holds
			// values with names that are just the integers 0,1,2,... giving the index
			// of each value.
			//
			foreach(FieldInfo fi in settings.GetType().GetFields(
				BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public))
			{ 
				object obj;

			    // If this field is an Enum it needs to be handled separately. The text
				// name for the enum is read from the registry.
				if(fi.FieldType.IsEnum)
				{
					if((obj=key.GetValue(fi.Name))!=null)
						fi.SetValue(settings,Enum.Parse(fi.FieldType,(string)obj));
				}

				// Otherwise each different field type is handled case by case using
				// a large switch statement that tests the lower case name of the Field type
				else
				{
				    RegistryKey subkey;
				    switch (fi.FieldType.Name.ToLower())
					{
						case "string":
							if((obj=key.GetValue(fi.Name))!=null)
								fi.SetValue(settings,obj);
							break;

						case "boolean":
							if((obj=key.GetValue(fi.Name))!=null)
								fi.SetValue(settings,bool.Parse((string)obj));
							break;

						case "int32":
							if((obj=key.GetValue(fi.Name))!=null)
								fi.SetValue(settings,(int)obj);
							break;

						case "decimal":
							if((obj=key.GetValue(fi.Name))!=null)
							{
								int theInt=(int)obj;
								fi.SetValue(settings,(decimal)theInt);
							}
							break;

						case "single":
							if((obj=key.GetValue(fi.Name))!=null)
								fi.SetValue(settings,float.Parse((string)obj));
							break;

						case "double":
							if((obj=key.GetValue(fi.Name))!=null)
								fi.SetValue(settings,double.Parse((string)obj));
							break;

						case "point":
							if((obj=key.GetValue(fi.Name+".X"))!=null)
							{
							    int x = (int)obj;
							    if((obj=key.GetValue(fi.Name+".Y"))!=null)
							    {
							        int y = (int)obj;
							        fi.SetValue(settings,new Point(x,y));
							    }
							}
					        break;

						case "size":
							if((obj=key.GetValue(fi.Name+".Height"))!=null)
							{
							    int height = (int)obj;
							    if((obj=key.GetValue(fi.Name+".Width"))!=null)
							    {
							        int width = (int)obj;
							        fi.SetValue(settings,new Size(width,height));
							    }
							}
					        break;

						// string arrays are a native registry type and thus easy to handle
						case "string[]":  // Get an array of strings
							if((obj=key.GetValue(fi.Name))!=null)
								fi.SetValue(settings,obj);
							break;

						// byte arrays are a native registry type and thus, easy to handle
						case "byte[]":  // Get an array of bytes
							if((obj=key.GetValue(fi.Name))!=null)
								fi.SetValue(settings,obj);
							break;

						case "int32[]":  // Get an array of ints
							if((subkey=key.OpenSubKey(fi.Name))!=null)
							{
								int i=0;
								int n=subkey.ValueCount;
								int[] integers = new int[n];
								while((obj=subkey.GetValue(i.ToString()))!=null)
									integers[i++]=(int)obj;
								fi.SetValue(settings,integers);
							}
							break;

						case "single[]":  // Get an array of floats
							if((subkey=key.OpenSubKey(fi.Name))!=null)
							{
								int i=0;
								int n=subkey.ValueCount;
								float[] floats = new float[n];
								while((obj=subkey.GetValue(i.ToString()))!=null)
								{
									floats[i++]=float.Parse((string)obj);
								}
								fi.SetValue(settings,floats);
							}
							break;

						case "double[]":  // Get an array of doubles
							if((subkey=key.OpenSubKey(fi.Name))!=null)
							{
								int i=0;
								int n=subkey.ValueCount;
								double[] doubles = new double[n];
								while((obj=subkey.GetValue(i.ToString()))!=null)
								{
									doubles[i++]=double.Parse((string)obj);
								}
								fi.SetValue(settings,doubles);
							}
							break;

						case "boolean[]":  // Get an array of booleans
							if((subkey=key.OpenSubKey(fi.Name))!=null)
							{
								int i=0;
								int n=subkey.ValueCount;
								bool[] bools = new bool[n];
								while((obj=subkey.GetValue(i.ToString()))!=null)
								{
									bools[i]=bool.Parse((string)obj);
									i++;
								}
								fi.SetValue(settings,bools);
							}
							break;

						// Colors are tricky. If it is a known named color it is easy, we just
						// use Color.FromName. If it is not a named color, than we have to decode
						// the Argb values from the hexadecimal number.
						// So we check to see if the string is a hexadecimal number and, if so
						// decode it as an Argb value, otherwise we reconstruct from the name
						// If the name is invalid, we should just get a default color value
						case "color":  // Get a Color
							if((obj=key.GetValue(fi.Name))!=null)
							{								
								string theColorName = (string)obj;
								Color theColor;
								if(IsHexadecimal(theColorName))
									theColor = Color.FromArgb(Int32.Parse(theColorName,NumberStyles.HexNumber));
								else
									theColor = Color.FromName(theColorName);
								fi.SetValue(settings,theColor);
							}
							break;

						case "timespan":  // Get a TimeSpan
							if((obj=key.GetValue(fi.Name))!=null)
								fi.SetValue(settings,TimeSpan.Parse((string)obj));
							break;

						case "datetime":  // Get a DateTime
							if((obj=key.GetValue(fi.Name))!=null)
								fi.SetValue(settings,DateTime.Parse((string)obj));
							break;

						case "font":
							if((obj=key.GetValue(fi.Name+".Name"))!=null)
							{
							    string name = (string)obj;
							    if((obj=key.GetValue(fi.Name+".Size"))!=null)
							    {
							        float emSize = float.Parse((string)obj);
							        if((obj=key.GetValue(fi.Name+".Style"))!=null)
							        {
							            FontStyle style = (FontStyle)Enum.Parse(typeof(FontStyle),(string)obj);
							            fi.SetValue(settings,new Font(name,emSize,style));
							        }
							    }
							}
					        break;

						default:
							MessageBox.Show("This type has not been implemented: "+fi.FieldType);
							break;
					}
				}
			}
		}

		public static void Read(object settings, string key)
		{
		    using (RegistryKey registryKey = Registry.CurrentUser.CreateSubKey(key))
		    {
                Read(settings, registryKey);
		    }
		}

		public static void Read(object settings)
		{
			RegistryKey key=Application.UserAppDataRegistry;
			Read(settings,key);
		}

		public static bool SaveToFile(object settings, string fileName)
		{
			try
			{
				IFormatter formatter = new BinaryFormatter();
				Stream stream = new FileStream(fileName, FileMode.Create,
					FileAccess.Write, FileShare.None);
				formatter.Serialize(stream, settings);
				stream.Close();
				return true;
			}
			catch
			{
				MessageBox.Show("Error attempting to save the settings to a file\n\n"+fileName,
					"Expresso Error",
					MessageBoxButtons.OK,MessageBoxIcon.Error);
				return false;
			}
		}

		public static object ReadFromFile(string fileName)
		{
			try
			{
				// First try to read the version information				
				IFormatter formatter = new BinaryFormatter();
				Stream stream = new FileStream(fileName, FileMode.Open,
					FileAccess.Read, FileShare.Read);
				object newSettings = formatter.Deserialize(stream);
				stream.Close();
				return newSettings;
			}
			catch
			{
				MessageBox.Show("Error attempting to read the settings from a file\n\n"+fileName,
					"Expresso Error",
					MessageBoxButtons.OK,MessageBoxIcon.Error);
				return null;   // If there is an error return null
			}
		}

		public static bool IsHexadecimal(string input)
		{
			foreach ( char c in input)
			{
				if(!Uri.IsHexDigit(c))return false;
			}
			return true;
		}
	}	
}
