/////////////////////////////////////////////////////////////////////////////
// SampleCppZooTestPlugIn.h : main header file for the SampleCppZooTest plug-in
//

#pragma once

/////////////////////////////////////////////////////////////////////////////
// CSampleCppZooTestPlugIn
// See SampleCppZooTestPlugIn.cpp for the implementation of this class
//

class CSampleCppZooTestPlugIn : public CRhinoUtilityPlugIn
{
public:
  CSampleCppZooTestPlugIn();
  ~CSampleCppZooTestPlugIn();

  // Required overrides
  const wchar_t* PlugInName() const;
  const wchar_t* PlugInVersion() const;
  GUID PlugInID() const;
  BOOL OnLoadPlugIn();
  void OnUnloadPlugIn();

private:
  ON_wString m_plugin_version;

  // TODO: Add additional class information here
};

CSampleCppZooTestPlugIn& SampleCppZooTestPlugIn();



