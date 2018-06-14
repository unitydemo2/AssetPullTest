{
   "content":    {
      "draftId": "5a5daafe4fdb5c1ef0568a2a",
      "draftName": "Coder Draft",
      "draftType": 1,
      "gDocFileId": "1WkYY1UHaAnd-yollGF2NjEBgzldVLrdkyO-iNvX3KeE",
      "gDocUrl": "https://docs.google.com/document/d/1WkYY1UHaAnd-yollGF2NjEBgzldVLrdkyO-iNvX3KeE/edit?usp=drivesdk",
      "latestSnapshotId": "5a5dab034fdb5c1ef0568a2b",
      "nodeId": "5a5daaf34fdb5c1ef0568a20",
      "contentAsMarkdown": "aksjdjdkjhdehf",
      "coderDraftId": "5a5daafe4fdb5c1ef0568a2a",
      "coderDraftSnapshotId": "5a5dab064fdb5c1ef0568a2c",
      "liveDraftId": "5a5dab064fdb5c1ef0568a2d",
      "liveDraftSnapshotId": "5a5dab064fdb5c1ef0568a2e",
      "nodeName": "UnityManual",
      "parentId": null,
      "fileName": "UnityManual.md",
      "distributionId": "5a5daae04fdb5c1ef0568a1f",
      "status": 0,
      "projectId": "5a5daad44fdb5c1ef0568a1e",
      "distributionName": "2087.01",
      "branchName": "DocworksManual2",
      "description": null,
      "isDefault": false,
      "repositoryId": 109930117,
      "typeOfContent": 3,
      "changeSetNumber": "358f86b9e92af1e0c692d5c7e99dc7e2125560f1"
   },
   "userId": "S-1-5-21-1210654208-2246142303-2829877410-19101",
   "flowMap":    {
      "cmsOperation": 12,
      "eventGroups":       [
         [         {
            "eventName": 4,
            "eventLocationInFlowMap": null,
            "status": 2,
            "childCMSOperation": 0,
            "childOperationStatus": null,
            "eventCondition": null,
            "reuseCmsOperation": 13,
            "conditionKeys": null,
            "requestMapProperty": null,
            "responseMapProperty": null
         }],
         [         {
            "eventName": 1016,
            "eventLocationInFlowMap": null,
            "status": 2,
            "childCMSOperation": 0,
            "childOperationStatus": null,
            "eventCondition": null,
            "reuseCmsOperation": 0,
            "conditionKeys": null,
            "requestMapProperty": [            {
               "source": "DraftId",
               "target": "DraftId"
            }],
            "responseMapProperty":             [
                              {
                  "source": "DraftId",
                  "target": "DraftId"
               },
                              {
                  "source": "DraftName",
                  "target": "DraftName"
               },
                              {
                  "source": "DraftType",
                  "target": "DraftType"
               },
                              {
                  "source": "GDocFileId",
                  "target": "GDocFileId"
               },
                              {
                  "source": "GDocUrl",
                  "target": "GDocUrl"
               },
                              {
                  "source": "LatestSnapshotId",
                  "target": "LatestSnapshotId"
               }
            ]
         }],
         [         {
            "eventName": 4002,
            "eventLocationInFlowMap": null,
            "status": 2,
            "childCMSOperation": 0,
            "childOperationStatus": null,
            "eventCondition": "Convert.ToInt32(DraftType)==2",
            "reuseCmsOperation": 0,
            "conditionKeys": ["DraftType"],
            "requestMapProperty": [            {
               "source": "GDocFileId",
               "target": "GDocFileId"
            }],
            "responseMapProperty": [            {
               "source": "ContentAsMarkdown",
               "target": "ContentAsMarkdown"
            }]
         }],
         [         {
            "eventName": 1017,
            "eventLocationInFlowMap": null,
            "status": 2,
            "childCMSOperation": 0,
            "childOperationStatus": null,
            "eventCondition": "Convert.ToInt32(DraftType)==1 || Convert.ToInt32(DraftType)==3",
            "reuseCmsOperation": 0,
            "conditionKeys": ["DraftType"],
            "requestMapProperty": [            {
               "source": "LatestSnapshotId",
               "target": "SnapshotId"
            }],
            "responseMapProperty": [            {
               "source": "DraftContent",
               "target": "ContentAsMarkdown"
            }]
         }],
         [         {
            "eventName": 1018,
            "eventLocationInFlowMap": null,
            "status": 2,
            "childCMSOperation": 0,
            "childOperationStatus": null,
            "eventCondition": "Convert.ToInt32(DraftType)==2",
            "reuseCmsOperation": 0,
            "conditionKeys": ["DraftType"],
            "requestMapProperty":             [
                              {
                  "source": "DraftId",
                  "target": "DraftId"
               },
                              {
                  "source": "ContentAsMarkdown",
                  "target": "DraftContent"
               },
                              {
                  "source": "IsDraftContentValid",
                  "target": "IsDraftContentValid"
               }
            ],
            "responseMapProperty": [            {
               "source": "LatestSnapshotId",
               "target": "LatestSnapshotId"
            }]
         }],
         [         {
            "eventName": 1022,
            "eventLocationInFlowMap": null,
            "status": 2,
            "childCMSOperation": 0,
            "childOperationStatus": null,
            "eventCondition": null,
            "reuseCmsOperation": 0,
            "conditionKeys": null,
            "requestMapProperty": [            {
               "source": "NodeId",
               "target": "NodeId"
            }],
            "responseMapProperty": [            {
               "source": "CoderDraftId",
               "target": "CoderDraftId"
            }]
         }],
         [         {
            "eventName": 1018,
            "eventLocationInFlowMap": null,
            "status": 2,
            "childCMSOperation": 0,
            "childOperationStatus": null,
            "eventCondition": null,
            "reuseCmsOperation": 0,
            "conditionKeys": null,
            "requestMapProperty":             [
                              {
                  "source": "CoderDraftId",
                  "target": "DraftId"
               },
                              {
                  "source": "ContentAsMarkdown",
                  "target": "DraftContent"
               },
                              {
                  "source": "IsDraftContentValid",
                  "target": "IsDraftContentValid"
               }
            ],
            "responseMapProperty": [            {
               "source": "LatestSnapshotId",
               "target": "CoderDraftSnapshotId"
            }]
         }],
         [         {
            "eventName": 1021,
            "eventLocationInFlowMap": null,
            "status": 2,
            "childCMSOperation": 0,
            "childOperationStatus": null,
            "eventCondition": null,
            "reuseCmsOperation": 0,
            "conditionKeys": null,
            "requestMapProperty": [            {
               "source": "NodeId",
               "target": "NodeId"
            }],
            "responseMapProperty": [            {
               "source": "LiveDraftId",
               "target": "LiveDraftId"
            }]
         }],
         [         {
            "eventName": 1018,
            "eventLocationInFlowMap": null,
            "status": 2,
            "childCMSOperation": 0,
            "childOperationStatus": null,
            "eventCondition": null,
            "reuseCmsOperation": 0,
            "conditionKeys": null,
            "requestMapProperty":             [
                              {
                  "source": "LiveDraftId",
                  "target": "DraftId"
               },
                              {
                  "source": "ContentAsMarkdown",
                  "target": "DraftContent"
               },
                              {
                  "source": "IsDraftContentValid",
                  "target": "IsDraftContentValid"
               }
            ],
            "responseMapProperty": [            {
               "source": "LatestSnapshotId",
               "target": "LiveDraftSnapshotId"
            }]
         }],
         [         {
            "eventName": 1030,
            "eventLocationInFlowMap": null,
            "status": 2,
            "childCMSOperation": 0,
            "childOperationStatus": null,
            "eventCondition": null,
            "reuseCmsOperation": 0,
            "conditionKeys": null,
            "requestMapProperty": [            {
               "source": "NodeId",
               "target": "NodeId"
            }],
            "responseMapProperty":             [
                              {
                  "source": "NodeName",
                  "target": "NodeName"
               },
                              {
                  "source": "ParentId",
                  "target": "ParentId"
               },
                              {
                  "source": "FileName",
                  "target": "FileName"
               },
                              {
                  "source": "DistributionId",
                  "target": "DistributionId"
               },
                              {
                  "source": "Status",
                  "target": "Status"
               }
            ]
         }],
         [         {
            "eventName": 1029,
            "eventLocationInFlowMap": null,
            "status": 2,
            "childCMSOperation": 0,
            "childOperationStatus": null,
            "eventCondition": null,
            "reuseCmsOperation": 0,
            "conditionKeys": null,
            "requestMapProperty": [            {
               "source": "DistributionId",
               "target": "DistributionId"
            }],
            "responseMapProperty":             [
                              {
                  "source": "ProjectId",
                  "target": "ProjectId"
               },
                              {
                  "source": "DistributionName",
                  "target": "DistributionName"
               },
                              {
                  "source": "BranchName",
                  "target": "BranchName"
               },
                              {
                  "source": "Description",
                  "target": "Description"
               },
                              {
                  "source": "IsDefault",
                  "target": "IsDefault"
               },
                              {
                  "source": "Status",
                  "target": "Status"
               }
            ]
         }],
         [         {
            "eventName": 1004,
            "eventLocationInFlowMap": null,
            "status": 2,
            "childCMSOperation": 0,
            "childOperationStatus": null,
            "eventCondition": null,
            "reuseCmsOperation": 0,
            "conditionKeys": null,
            "requestMapProperty": [            {
               "source": "ProjectId",
               "target": "ProjectId"
            }],
            "responseMapProperty":             [
                              {
                  "source": "ProjectId",
                  "target": "ProjectId"
               },
                              {
                  "source": "RepositoryId",
                  "target": "RepositoryId"
               },
                              {
                  "source": "TypeOfContent",
                  "target": "TypeOfContent"
               }
            ]
         }],
         [         {
            "eventName": 3010,
            "eventLocationInFlowMap": null,
            "status": 2,
            "childCMSOperation": 0,
            "childOperationStatus": null,
            "eventCondition": null,
            "reuseCmsOperation": 0,
            "conditionKeys": null,
            "requestMapProperty":             [
                              {
                  "source": "ProjectId",
                  "target": "ProjectId"
               },
                              {
                  "source": "RepositoryId",
                  "target": "RepositoryId"
               },
                              {
                  "source": "DistributionId",
                  "target": "DistributionId"
               },
                              {
                  "source": "BranchName",
                  "target": "BranchName"
               },
                              {
                  "source": "ContentAsMarkdown",
                  "target": "FileContent"
               },
                              {
                  "source": "FileName",
                  "target": "RelativeFilePath"
               }
            ],
            "responseMapProperty": [            {
               "source": "ChangeSetNumber",
               "target": "ChangeSetNumber"
            }]
         }],
         [         {
            "eventName": 1028,
            "eventLocationInFlowMap": null,
            "status": 2,
            "childCMSOperation": 0,
            "childOperationStatus": null,
            "eventCondition": "ChangeSetNumber != \"\" && ChangeSetNumber != null",
            "reuseCmsOperation": 0,
            "conditionKeys": ["ChangeSetNumber"],
            "requestMapProperty":             [
                              {
                  "source": "LiveDraftSnapshotId",
                  "target": "SnapshotId"
               },
                              {
                  "source": "ChangeSetNumber",
                  "target": "ChangeSetNumber"
               }
            ],
            "responseMapProperty": null
         }]
      ],
      "notificationType": 1,
      "notificationTopic": "NA",
      "parentResponseId": null,
      "parentEventLocation": null,
      "isOperationCompleteWithStatusSuccess": true,
      "_id": "5a5d9ba1a0768b2b5cb9c86a",
      "status": 0,
      "modifiedDate": 0,
      "createdDate": 1516084129
   },
   "createdOn": "2018-01-16T07:34:29.41Z",
   "errorResponse": null,
   "_id": "5a5dab05df37671f2ccd39bf",
   "status": 2,
   "modifiedDate": 1516088070,
   "createdDate": 1516088069
}