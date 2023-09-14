using System.IO;
using OpenGameFramework.Editor;
using OpenGameTech.Editor.OpenModuleSystem.Features.ModuleCreatorPluginSystem;
using OpenGameTech.Editor.OpenModuleSystem.Modules.Features.CreateModule;
using UnityEngine;
using Constants = OpenGameFramework.Editor.EditorConstantsForModuleSystem;

[ModuleCreatorPlugin("X-Flow/Singleton Module")]
public class XFlowModuleCreator : IModuleCreatorStrategy
{
    public void Create(string moduleFolder, ModuleInfo moduleInfo, CreateModuleWindow.CreateModuleOptions options)
    {
        Debug.Log("Xflow");
        string filePath = Constants.PathToAppModules + moduleFolder + "/" + moduleInfo.name;
            var managerName = moduleInfo.custom_manager_name == string.Empty
                ? moduleInfo.name + Constants.Manager
                : moduleInfo.custom_manager_name;
            var serviceName = moduleInfo.custom_manager_name == string.Empty
                ? moduleInfo.name + Constants.Service
                : moduleInfo.custom_manager_name;

            string[] fileNames =
            {
                Constants.ModuleInfoFileName,
                moduleInfo.name + "SingletonParts.cs",
                managerName + ".cs",
                moduleInfo.name + "Hooks.cs",
                moduleInfo.name + "Store.cs",
                serviceName + ".cs",
                "I" + moduleInfo.name + "SystemService.cs",
                "I" + moduleInfo.name + "DomainService.cs",
                moduleInfo.name + "Config.cs"
            };

            if (!Directory.Exists(Path.Combine(Application.dataPath, filePath)))
            {
                // module-info.json
                Directory.CreateDirectory(Path.Combine(Application.dataPath, filePath));
                moduleInfo.hash = ModuleCreator.GenerateModuleHash(moduleInfo.name);

                File.WriteAllText(Path.Combine(Application.dataPath, filePath, fileNames[0]),
                    JsonUtility.ToJson(moduleInfo));

                // Parts
                // ModuleCreator.WriteFileBaseOnTemplate(Constants.PathToSingletonPartsScriptTemplate, filePath,
                //     fileNames[1],
                //     managerName);

                // Singleton Manager
                ModuleCreator.WriteFileBaseOnTemplate("App/Core/Tools/OpenModulesSystem/Plugins/XFlowModules/Templates/ManagerSingleton.cs.tmpl", 
                    filePath, fileNames[2], managerName);


                if (options.HasFlag(CreateModuleWindow.CreateModuleOptions.Hooks))
                {
                    // Hooks
                    ModuleCreator.WriteFileBaseOnTemplate(Constants.PathToHooksScriptTemplate, filePath, fileNames[3],
                        moduleInfo.name);
                }

                if (options.HasFlag(CreateModuleWindow.CreateModuleOptions.Store))
                {
                    // Store
                    // ModuleFabric.WriteFileBaseOnTemplate(Constants.PathToStoreScriptTemplate, filePath, fileNames[4], _moduleInfo.name);
                }

                // Config For Module
                ModuleCreator.WriteFileBaseOnTemplate(Path.GetFullPath(Constants.PathToConfigSOTemplate), filePath, fileNames[8],
                    moduleInfo.name);
                
                ProjectInfo info = AllModulesWindow.GetProjectManifest();
                info.config_for_generate = $"{filePath}--{moduleInfo.name}";
                AllModulesWindow.SaveProjectManifest();
                
                // Create asmdef
                string[] asmRefs = new[]
                {
                    "App.GameCore",
                    "OGT.OpenModuleSystem",
                    "medvedya.select_implementation_property_drawer"
                };
                
                ModuleCreator.AsmDefGenerator.GenerateAsmDef($"App.{moduleInfo.name}", filePath, $"App.{moduleInfo.name}.asmdef", asmRefs);

                // Update App.Core asmdef
                ModuleCreator.AsmDefGenerator.UpdateAppCoreAsmDefRefs("App/Core/App.Core.asmdef", $"App.{moduleInfo.name}");
                
                // Create GameBlock directory
                Directory.CreateDirectory(Path.Combine(Application.dataPath, filePath));
                
                AllModulesWindow.UpdatePreInit();
            }
            else
            {
                Debug.LogError(Constants.L_ModuleWithNameExist);
            }
    }
}
