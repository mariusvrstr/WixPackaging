<?xml version="1.0" encoding="utf-8" ?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
                xmlns:msxl="urn:schemas-microsoft-com:xslt"
                exclude-result-prefixes="msxl"
                xmlns:wix="http://schemas.microsoft.com/wix/2006/wi">

  <xsl:output method="xml" version="1.0" encoding="utf-8" indent="yes" />
  <xsl:strip-space elements="*" />

  <!-- Get harvest file details -->
  <xsl:template match="@*|node()">
    <xsl:copy>
      <xsl:apply-templates select="@*|node()" />
    </xsl:copy>
  </xsl:template>

  <!-- Match and ignore PDF file types -->
  <xsl:key name="pdb-search" match="wix:Component[contains(wix:File/@Source, '.pdb')]" use="@Id" />
  <xsl:template match="wix:Component[key('pdb-search', @Id)]" />
  <xsl:template match="wix:ComponentRef[key('pdb-search', @Id)]" />

  <!-- Match and ignore VHOST files -->
  <xsl:key name="vhost-search" match="wix:Component[contains(wix:File/@Source, 'vshost')]" use="@Id" />
  <xsl:template match="wix:Component[key('vhost-search', @Id)]" />
  <xsl:template match="wix:ComponentRef[key('vhost-search', @Id)]" />

  <!-- Match Application EXE and make it a SERVICE -->
  <xsl:template match="wix:Component[wix:File[@Source='$(var.HostFileDir)\Spike.ConsoleApp.exe']]">
    <xsl:copy>
      <xsl:apply-templates select="@*|node()" />
      <wix:ServiceInstall Id="ServiceInstaller" Type="ownProcess" Name="[SERVICENAME]" DisplayName="[SERVICEDESCRIPTION]" Description="[SERVICEDESCRIPTION]" Start="auto" Account="[SERVICEACCOUNT]" Password="[SERVICEPASSWORD]" ErrorControl="ignore" Interactive="no" />
      <wix:ServiceControl Id="StartService" Start="install" Stop="both" Remove="uninstall" Name="[SERVICENAME]" Wait="yes" />
    </xsl:copy>
  </xsl:template>

</xsl:stylesheet>


