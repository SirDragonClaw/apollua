﻿// InteropHelpers.cs
//
// Lua 5.1 is copyright © 1994-2008 Lua.org, PUC-Rio, released under the MIT license
// LuaCLR is copyright © 2007-2008 Fabio Mascarenhas, released under the MIT license
// This version copyright © 2009 Edmund Kapusniak


using System;


namespace Lua.Interop
{


public static class InteropHelpers
{
	// Constants.

	public static readonly Value[] EmptyValues = new Value[] {};



	// Casting.

	public static T Cast< T >( Value v )
	{
		if ( v == null )
		{
			return default( T );
		}
		else if ( typeof( T ) == typeof( Value ) )
		{
			return (T)(object)v;
		}
		else if ( typeof( T ) == typeof( bool ) )
		{
			return (T)(object)v.IsTrue();
		}
		else if ( typeof( T ) == typeof( sbyte ) )
		{
			int integer;
			if ( v.TryToInteger( out integer ) )
			{
				sbyte i;
				checked { i = (sbyte)integer; }
				return (T)(object)i;
			}
		}
		else if ( typeof( T ) == typeof( byte ) )
		{
			int integer;
			if ( v.TryToInteger( out integer ) )
			{
				byte i;
				checked { i = (byte)integer; }
				return (T)(object)i;
			}
		}
		else if ( typeof( T ) == typeof( short ) )
		{
			int integer;
			if ( v.TryToInteger( out integer ) )
			{
				short i;
				checked { i = (short)integer; }
				return (T)(object)i;
			}
		}
		else if ( typeof( T ) == typeof( ushort ) )
		{
			int integer;
			if ( v.TryToInteger( out integer ) )
			{
				ushort i;
				checked { i = (ushort)integer; }
				return (T)(object)i;
			}
		}
		else if ( typeof( T ) == typeof( int ) )
		{
			int integer;
			if ( v.TryToInteger( out integer ) )
			{
				return (T)(object)integer;
			}
		}
		else if ( typeof( T ) == typeof( long ) )
		{
			int integer;
			if ( v.TryToInteger( out integer ) )
			{
				long i = integer;
				return (T)(object)i;
			}
		}
		else if ( typeof( T ) == typeof( ulong ) )
		{
			int integer;
			if ( v.TryToInteger( out integer ) )
			{
				ulong i;
				checked { i = (ulong)integer; }
				return (T)(object)i;
			}
		}
		else if ( typeof( T ) == typeof( float ) )
		{
			if ( v.GetType() == typeof( BoxedInteger ) )
			{
				float real = ( (BoxedInteger)v ).Value;
				return (T)(object)real;
			}
			else if ( v.GetType() == typeof( BoxedNumber ) )
			{
				float real;
				checked { real = (float)( (BoxedNumber)v ).Value; }
				return (T)(object)real;
			}
		}
		else if ( typeof( T ) == typeof( double ) )
		{
			if ( v.GetType() == typeof( BoxedInteger ) )
			{
				double real = ( (BoxedInteger)v ).Value;
				return (T)(object)real;
			}
			else if ( v.GetType() == typeof( BoxedNumber ) )
			{
				return (T)(object)( (BoxedNumber)v ).Value;
			}
		}
		else if ( typeof( T ) == typeof( decimal ) )
		{
			if ( v.GetType() == typeof( BoxedInteger ) )
			{
				decimal real = ( (BoxedInteger)v ).Value;
				return (T)(object)real;
			}
			else if ( v.GetType() == typeof( BoxedNumber ) )
			{
				decimal real;
				checked { real = (decimal)( (BoxedNumber)v ).Value; }
				return (T)(object)real;
			}
		}
		else if ( typeof( T ) == typeof( string ) )
		{
			if ( v.GetType() == typeof( BoxedString ) )
			{
				return (T)(object)( (BoxedString)v ).Value;
			}
		}

		throw new InvalidCastException();
	}

	public static T Cast< T >( Value[] values, int index )
	{
		if ( index < values.Length )
		{
			return Cast< T >( values[ index ] );
		}
		else
		{
			return Cast< T >( null );
		}
	}

	public static T[] CastParams< T >( Value[] values, int index )
	{
		if ( index < values.Length )
		{
			T[] arguments = new T[ values.Length - index ];
			for ( int argument = 0; argument < arguments.Length; ++argument )
			{
				arguments[ argument ] = Cast< T >( values[ index + argument ] );
			}
			return arguments;
		}
		else
		{
			return new T[] {};
		}
	}

	public static Value CastResultS< T >( T v )
	{
		if ( v == null )
		{
			return null;
		}
		else if ( typeof( T ) == typeof( Value ) )
		{
			return (Value)(object)v;
		}
		else if ( typeof( T ) == typeof( bool ) )
		{
			return (bool)(object)v ? BoxedBoolean.True : BoxedBoolean.False;
		}
		else if ( typeof( T ) == typeof( sbyte ) )
		{
			return new BoxedInteger( (sbyte)(object)v );
		}
		else if ( typeof( T ) == typeof( byte ) )
		{
			return new BoxedInteger( (byte)(object)v );
		}
		else if ( typeof( T ) == typeof( short ) )
		{
			return new BoxedInteger( (short)(object)v );
		}
		else if ( typeof( T ) == typeof( ushort ) )
		{
			return new BoxedInteger( (ushort)(object)v );
		}
		else if ( typeof( T ) == typeof( int ) )
		{
			return new BoxedInteger( (int)(object)v );
		}
		else if ( typeof( T ) == typeof( uint ) )
		{
			uint integer = (uint)(object)v;
			checked { return new BoxedInteger( (int)integer ); }
		}
		else if ( typeof( T ) == typeof( long ) )
		{
			long integer = (long)(object)v;
			checked { return new BoxedInteger( (int)integer ); }
		}
		else if ( typeof( T ) == typeof( ulong ) )
		{
			ulong integer = (ulong)(object)v;
			checked { return new BoxedInteger( (int)integer ); }
		}
		else if ( typeof( T ) == typeof( float ) )
		{
			return new BoxedNumber( (float)(object)v );
		}
		else if ( typeof( T ) == typeof( double ) )
		{
			return new BoxedNumber( (double)(object)v );
		}
		else if ( typeof( T ) == typeof( decimal ) )
		{
			decimal real = (decimal)(object)v;
			checked { return new BoxedNumber( (double)real ); }
		}
		else if ( typeof( T ) == typeof( string ) )
		{
			return new BoxedString( (string)(object)v );
		}

		throw new NotSupportedException();
	}

	public static Value[] CastResultM< T >( T v )
	{
		return new Value[] { CastResultS( v ) };
	}

	public static Value CastResultListS< T >( T[] values )
	{
		if ( values.Length > 0 )
		{
			return CastResultS( values[ 0 ] );
		}
		else
		{
			return null;
		}
	}

	public static Value[] CastResultListM< T >( T[] values )
	{
		Value[] results = new Value[ values.Length ];
		for ( int result = 0; result < values.Length; ++result )
		{
			results[ result ] = CastResultS( values[ result ] );
		}
		return results;
	}



}



}


