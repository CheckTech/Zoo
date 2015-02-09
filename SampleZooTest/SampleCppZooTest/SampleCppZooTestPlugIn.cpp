/////////////////////////////////////////////////////////////////////////////
// SampleCppZooTestPlugIn.cpp : defines the initialization routines for the plug-in.
//

#include "StdAfx.h"
#include "SampleCppZooTestPlugIn.h"

#pragma warning( push )
#pragma warning( disable : 4073 )
#pragma init_seg( lib )
#pragma warning( pop )

// Rhino plug-in declaration
RHINO_PLUG_IN_DECLARE

// Rhino plug-in name
RHINO_PLUG_IN_NAME( L"SampleCppZooTest" );

// Rhino plug-in id
RHINO_PLUG_IN_ID( L"a8db70d4-f568-498f-968c-0129418e3c2d" );

// Rhino plug-in version
RHINO_PLUG_IN_VERSION( __DATE__"  "__TIME__ )

// Rhino plug-in developer declarations
RHINO_PLUG_IN_DEVELOPER_ORGANIZATION( L"Robert McNeel & Associates" );
RHINO_PLUG_IN_DEVELOPER_ADDRESS( L"3670 Woodland Park Avenue North\r\nSeattle, WA 98115" );
RHINO_PLUG_IN_DEVELOPER_COUNTRY( L"United States" );
RHINO_PLUG_IN_DEVELOPER_PHONE( L"(206) 545-6877" );
RHINO_PLUG_IN_DEVELOPER_FAX( L"(206) 545-7321" );
RHINO_PLUG_IN_DEVELOPER_EMAIL( L"support@mycompany.com" );
RHINO_PLUG_IN_DEVELOPER_WEBSITE( L"http://www.rhino3d.com/zoo" );
RHINO_PLUG_IN_UPDATE_URL( L"https://github.com/mcneel/Zoo5" );

// The one and only CSampleCppZooTestPlugIn object
static CSampleCppZooTestPlugIn thePlugIn;

/////////////////////////////////////////////////////////////////////////////
// CSampleCppZooTestPlugIn definition

CSampleCppZooTestPlugIn& SampleCppZooTestPlugIn()
{ 
  // Return a reference to the one and only CSampleCppZooTestPlugIn object
  return thePlugIn; 
}

CSampleCppZooTestPlugIn::CSampleCppZooTestPlugIn()
{
  // TODO: Add construction code here
  m_plugin_version = RhinoPlugInVersion();
}

CSampleCppZooTestPlugIn::~CSampleCppZooTestPlugIn()
{
  // TODO: Add destruction code here
}

/////////////////////////////////////////////////////////////////////////////
// Required overrides

const wchar_t* CSampleCppZooTestPlugIn::PlugInName() const
{
  // TODO: Return a short, friendly name for the plug-in.
  return RhinoPlugInName();
}

const wchar_t* CSampleCppZooTestPlugIn::PlugInVersion() const
{
  // TODO: Return the version number of the plug-in.
  return m_plugin_version;
}

GUID CSampleCppZooTestPlugIn::PlugInID() const
{
  // TODO: Return a unique identifier for the plug-in.
  // {1F88325E-FA51-4B61-B3AC-27B589B70670}
  return ON_UuidFromString( RhinoPlugInId() );
}

BOOL CSampleCppZooTestPlugIn::OnLoadPlugIn()
{
  // Ask Rhino to get a product license for us.
  bool rc = GetLicense();
  if( !rc )
    return -1; // Unable to initialize, unload the plug-in
               // and do not display load error dialog 

  return TRUE;
}

void CSampleCppZooTestPlugIn::OnUnloadPlugIn()
{
}

