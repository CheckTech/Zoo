/////////////////////////////////////////////////////////////////////////////
// SampleCppZooTestApp.h : main header file for the SampleCppZooTest DLL
//

#pragma once

#ifndef __AFXWIN_H__
	#error include 'stdafx.h' before including this file for PCH
#endif

#include "Resource.h"		// main symbols

/////////////////////////////////////////////////////////////////////////////
// CSampleCppZooTestApp
// See SampleCppZooTestApp.cpp for the implementation of this class
//

class CSampleCppZooTestApp : public CWinApp
{
public:
	CSampleCppZooTestApp();

// Overrides
public:
	virtual BOOL InitInstance();
	virtual int ExitInstance();

	DECLARE_MESSAGE_MAP()
};
