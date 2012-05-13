Schematismi
=======================

Helps you to configure applications post installation.

You will be able to save a master xml configuration file that contains all the settings you want to modify, along with the values you want to use.

```xml
<configurationTool>
  
  <!-- application configuration -->
  <application name="app1">
    
    <!-- one of the files to configure -->
    <config fileName="db.config">
      
      <!-- attributes to replace value -->
      <attributes>
        <attribute 
          xpath="/connectionStrings/add[@name='Default']" 
          attribute="connectionString"
          value="Server=DEFAULT;Database=DEFAULT;uid=DEFAULT;pwd=DEFAULT;" />

        <attribute
          xpath="/connectionStrings/add[@name='Other']"
          attribute="connectionString"
          value="Server=OTHER;Database=OTHER;uid=OTHER;pwd=OTHER;" />
      </attributes>
      
      <!-- elements to replace value -->
      <elements>
        <element 
          xpath="/connectionStrings/myElement[@name='test']"
          value="NEW VALUE"
          />
      </elements>
      
    </config>
    
    
  </application>
  
  
  
  
  <!--<application name="app2">
    <config fileName="db.config">
      <item xpath="/connectionStrings/add[@connectionString]" value="Server=REPLACED;Database=REPLACED;uid=REPLACED;pwd=REPLACED;" />
    </config>
  </application>-->
  
</configurationTool>
```