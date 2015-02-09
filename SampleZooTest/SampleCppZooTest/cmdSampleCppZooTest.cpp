/////////////////////////////////////////////////////////////////////////////
// cmdSampleCppZooTest.cpp : command file
//

#include "StdAfx.h"
#include "SampleCppZooTestPlugIn.h"

////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////
//
// BEGIN SampleCppZooTest command
//

#pragma region SampleCppZooTest command

class CCommandSampleCppZooTest : public CRhinoCommand
{
public:
  CCommandSampleCppZooTest() {}
  ~CCommandSampleCppZooTest() {}
  UUID CommandUUID()
  {
    // {9A95C5F8-9309-4FE5-A97F-6EA783AB9024}
    static const GUID SampleCppZooTestCommand_UUID =
    { 0x9A95C5F8, 0x9309, 0x4FE5, { 0xA9, 0x7F, 0x6E, 0xA7, 0x83, 0xAB, 0x90, 0x24 } };
    return SampleCppZooTestCommand_UUID;
  }
  const wchar_t* EnglishCommandName() { return L"SampleCppZooTest"; }
  const wchar_t* LocalCommandName() const { return L"SampleCppZooTest"; }
  CRhinoCommand::result RunCommand( const CRhinoCommandContext& );
};

static class CCommandSampleCppZooTest theSampleCppZooTestCommand;

CRhinoCommand::result CCommandSampleCppZooTest::RunCommand( const CRhinoCommandContext& context )
{
  ON_wString wStr;
  wStr.Format( L"The \"%s\" command is under construction.\n", EnglishCommandName() );
  if( context.IsInteractive() )
    RhinoMessageBox( wStr, PlugIn()->PlugInName(), MB_OK );
  else
    RhinoApp().Print( wStr );
  return CRhinoCommand::success;
}

#pragma endregion

//
// END SampleCppZooTest command
//
////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////
