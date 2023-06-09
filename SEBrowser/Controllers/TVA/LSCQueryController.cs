﻿//******************************************************************************************************
//  LSCQueryController.cs - Gbtc
//
//  Copyright © 2020, Grid Protection Alliance.  All Rights Reserved.
//
//  Licensed to the Grid Protection Alliance (GPA) under one or more contributor license agreements. See
//  the NOTICE file distributed with this work for additional information regarding copyright ownership.
//  The GPA licenses this file to you under the MIT License (MIT), the "License"; you may not use this
//  file except in compliance with the License. You may obtain a copy of the License at:
//
//      http://opensource.org/licenses/MIT
//
//  Unless agreed to in writing, the subject software distributed under the License is distributed on an
//  "AS-IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. Refer to the
//  License for the specific language governing permissions and limitations.
//
//  Code Modification History:
//  ----------------------------------------------------------------------------------------------------
//  03/24/2020 - Billy Ernest
//       Generated original version of source code.
//
//******************************************************************************************************

using GSF.Data;
using System;
using System.Data;
using System.Web.Http;

namespace SEBrowser.Controllers
{
    [RoutePrefix("api/LSC")]
    public class LSCQueryController : ApiController
    {
        const string SettingsCategory = "systemSettings";

        [Route("{eventID:int}"), HttpGet]
        public IHttpActionResult Get(int eventID) {
            try
            {
                using(AdoDataConnection connection = new(SettingsCategory))
                {

                    DataTable table = connection.RetrieveData(@" 
                        exec dbo.GetAllImpactedComponents {0}
                    ", eventID );
                    return Ok(table);
                }
            }
            catch (Exception ex) {
                return InternalServerError(ex);
            }
        }

    }
}