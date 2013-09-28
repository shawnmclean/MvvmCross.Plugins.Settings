include Rake::DSL
require 'albacore'
require 'version_bumper'

CORE_LIB = 'src/MvvmCross.Plugins.Settings/bin/Release/MvvmCross.Plugins.Settings.dll'
WINPHONE_LIB = 'src/MvvmCross.Plugins.Settings.WindowsPhone/bin/Release/MvvmCross.Plugins.Settings.WindowsPhone.dll'

task :deploy,[:build] => [:zip, :nuget_push] do
end

zip :zip => :output do | zip |
	Dir.mkdir("build") unless Dir.exists?("build")
    zip.directories_to_zip "out"
    zip.output_file = "MvvmCross.Plugins.Settings.v#{bumper_version.to_s}.zip"
    zip.output_path = "build"
end

output :output => :test do |out|
	out.from '.'
	out.to 'out'
	out.file CORE_LIB, :as=>'MvvmCross.Plugins.Settings.dll'
	out.file WINPHONE_LIB, :as=>'MvvmCross.Plugins.Settings.WindowsPhone.dll'
	out.file 'LICENSE'
	out.file 'README.md'
	out.file 'VERSION'
end

desc "Test"
nunit :test => :build do |nunit|
	nunit.command = "tools/NUnit/nunit-console.exe"
	nunit.assemblies "test/MvvmCross.Plugins.Settings.Tests/bin/Release/MvvmCross.Plugins.Settings.Tests.dll"
end

desc "Build"
msbuild :build => :assemblyinfo do |msb|
  msb.properties :configuration => :Release
  msb.targets :Clean, :Build
  msb.solution = "MvvmCross.Plugins.Settings.sln"
end

##use this until patched
task :nup => :nus do
	sh "tools/NuGet/NuGet.exe pack -BasePath out/ -Output build/ out/MvvmCross.Plugins.Settings.nuspec"
end

nuspec :nus => :output do |nuspec|
   nuspec.id="MvvmCross.Plugins.Settings"
   nuspec.version = bumper_version.to_s
   nuspec.authors = "Shawn Mclean"
   nuspec.description = "Core Settings plugin for MvvmCross."
   nuspec.title = "MvvmCross.Plugins.Settings"
   nuspec.language = "en-US"
   nuspec.licenseUrl = "http://www.apache.org/licenses/LICENSE-2.0"
   nuspec.dependency "MvvmCross", "3.0.12"
   nuspec.projectUrl = "https://github.com/shawnmclean/MvvmCross.Plugins.Settings"
   nuspec.working_directory = "out/"
   nuspec.output_file = "MvvmCross.Plugins.Settings.nuspec"
   nuspec.file "MvvmCross.Plugins.Settings.dll", "lib"
end

nuspec :nusWinPhone => :output do |nuspec|
   nuspec.id="MvvmCross.Plugins.Settings.WindowsPhone"
   nuspec.version = bumper_version.to_s
   nuspec.authors = "Shawn Mclean"
   nuspec.description = "Windows Phone Settings plugin for MvvmCross."
   nuspec.title = "MvvmCross.Plugins.Settings.WindowsPhone"
   nuspec.language = "en-US"
   nuspec.licenseUrl = "http://www.apache.org/licenses/LICENSE-2.0"
   nuspec.dependency "MvvmCross.Plugins.Settings", "0.0.0.1"
   nuspec.projectUrl = "https://github.com/shawnmclean/MvvmCross.Plugins.Settings"
   nuspec.working_directory = "out/"
   nuspec.output_file = "MvvmCross.Plugins.Settings.WindowsPhone.nuspec"
   nuspec.file "MvvmCross.Plugins.Settings.WindowsPhone.dll", "lib"
end

assemblyinfo :assemblyinfo do |asm|
  asm.version = bumper_version.to_s
  asm.file_version = bumper_version.to_s
  asm.company_name = "Self"
  asm.product_name = "MvvmCross.Plugins.Settings"
  asm.copyright = "Shawn Mclean (c) 2013"
  asm.output_file = "AssemblyInfo.cs"
end